using optimalDb.Contracts;
using optimalDb.Persistence;

namespace optimalDb.Domain.CodeActions;

public class RepositoryCSharpCodeAction : CSharpCodeAction
{
    public RepositoryCSharpCodeAction() : base("C# Repository")
    {
    }

    public override string Execute(
        IDatabaseAccessor databaseAccessor,
        string connectionString, 
        string database, 
        string databaseObjectSchema, 
        string databaseObjectName,
        DatabaseObjectTypeEnum? databaseObjectTypeEnum)
    {
        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

        if (databaseObjectTypeEnum != DatabaseObjectTypeEnum.Table &&
            databaseObjectTypeEnum != DatabaseObjectTypeEnum.View)
        {
            return "";
        }

        var className = DotNetClassName(databaseObjectName);
        var tableName = databaseObjectName;
        var columns = schemaRepository.GetColumnList(databaseObjectSchema, databaseObjectName);

        var columnParameters = string.Join(Environment.NewLine,
            columns.Select(x => "    public " + DotNetDataType(x) + " " + DotNetNamePascalCase(x) + " { get; }")
        );

        var columnArguments =
            string.Join("," + Environment.NewLine,
                columns.Select(x => "        " + DotNetDataType(x) + " " + DotNetNameCamelCase(x))
            );

        var parameterAssignment =
            string.Join("," + Environment.NewLine,
                columns.Select(x => "        " + DotNetNamePascalCase(x) + " = " + DotNetNameCamelCase(x))
            );

        var saveColumnAssignments = string.Join(", " + Environment.NewLine,
            columns.Select(x => "            @" + x.ColumnName + " = @" + x.ColumnName));

        var saveColumnValues = string.Join(", " + Environment.NewLine,
            columns.Select(x =>
                "                { \"@" + x.ColumnName + "\", record." + DotNetNamePascalCase(x) + " }"));


        var columnNames = string.Join(", ", columns.Select(x => x.ColumnName));


        var instanciateArguments = string.Join("," + Environment.NewLine,
            columns.Select(x => "                row[\"" + x.ColumnName + "\"]." + ConverterToDotNetName(x)));

        var template = $@"
public class {className}Repository
{{
    private readonly IDatabaseAccessor _databaseAccessor;

    public {className}Repository(IDatabaseAccessor databaseAccessor)
    {{
        _databaseAccessor = databaseAccessor;
    }}

    public void Clear()
    {{
        var sql = @""EXEC dbo.{tableName}_Clear"";

        _databaseAccessor.ExecuteSql(sql);
    }}

    public void Save({className} record)
    {{
        var sql = @""
EXEC dbo.{tableName}_Save 
{saveColumnAssignments}
"";

        _databaseAccessor.ExecuteSql(sql, new Dictionary<string, object>{{
{saveColumnValues}
        }});

    }}

    public {className}[] GetList() 
    {{
        var sql = @""
SELECT {columnNames}
  FROM {databaseObjectSchema}.{tableName}
"";

        var daten = _databaseAccessor.LoadDataTable(sql);
        return daten.ToInstancesOf(Instanciate);
    }}

    private {className} Instanciate(DataRow row) 
    {{
        return new {className}(
{instanciateArguments}
        );
    }}
}}
        ";

        return template;
    }


}
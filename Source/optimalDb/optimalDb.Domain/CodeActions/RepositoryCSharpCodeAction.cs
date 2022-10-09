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

        var allColumns = schemaRepository.GetColumnsIncludingPrimaryKeys(databaseObjectSchema, databaseObjectName);
        var primaryKeys = schemaRepository.GetPrimaryKeyList(databaseObjectSchema, databaseObjectName);
        var allColumnsWithoutPrimaryKeys = schemaRepository.GetColumnList(databaseObjectSchema, databaseObjectName);

        var className = NamingHelper.DotNetClassName(databaseObjectName);
        var tableName = databaseObjectName;

        var saveColumnAssignments = string.Join(", " + Environment.NewLine,
            allColumns.Select(x => "            @" + x.ColumnName + " = @" + x.ColumnName));

        var saveColumnValues = string.Join(", " + Environment.NewLine,
            allColumns.Select(x =>
                "                { \"@" + x.ColumnName + "\", record." + NamingHelper.DotNetNamePascalCase(x) + " }"));


        var columnNames = string.Join(", ", allColumns.Select(x => x.ColumnName));

        var primaryKeyNameSqlParameter = primaryKeys.AsParameters();
        var primaryKeyNameDotNetParameter = primaryKeys.AsDotNetParameters();
        var primaryKeyNameDotNetName = primaryKeys.AsDotNetName();
        var primaryKeyNameSqlName = primaryKeys.AsSqlName();
        

        var instanciateArguments = string.Join("," + Environment.NewLine,
            allColumns.Select(x => "                row[\"" + x.ColumnName + "\"]." + NamingHelper.ConverterToDotNetName(x)));

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

    public int Save({className} record)
    {{
        var sql = @""
EXEC dbo.{tableName}_Save 
{saveColumnAssignments}
"";

        var newId = _databaseAccessor.LoadScalar(sql, new Dictionary<string, object>{{
{saveColumnValues}
        }}).ToInt();

        return newId;
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

    public {className}[] GetById({primaryKeyNameDotNetParameter}) 
    {{
        var sql = @""
SELECT {columnNames}
  FROM {databaseObjectSchema}.{tableName}
 WHERE {primaryKeyNameSqlName} = {primaryKeyNameSqlParameter}
"";

        var daten = _databaseAccessor.LoadDataTable(sql, new Dictionary<string,object>(
           {{ ""{primaryKeyNameSqlParameter}"", {primaryKeyNameDotNetName} }}
        ));
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
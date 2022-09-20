using optimalDb.BL;

namespace optimalDb.Infrastructure.CodeActions;

public class RepositoryCSharpCodeAction : CSharpCodeAction
{
    public RepositoryCSharpCodeAction() : base("C# Repository")
    {
    }

    public override string Execute(
        string connectionString, 
        string database, 
        string databaseObjectSchema, 
        string databaseObjectName,
        DatabaseObjectTypeEnum? databaseObjectTypeEnum)
    {
        var databaseAccessor = new DatabaseAccessor(connectionString);
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

        //var saveColumnAssignments = 
        //    string.Join()

            /*
             *         $columns = Get-DBColumn -TABLE_CATALOG $database -TABLE_SCHEMA $schema -TABLE_NAME $tablename



        $columnParameters = [string]::Join(', ', ($columns | ForEach-Object { "@" + $_.COLUMN_NAME + " " + (Get-DBColumnSQLDataType $_) }))

        $columnNames = [string]::Join(', ', $columns.COLUMN_NAME)

        $columnValues = [string]::Join(', ', ($columns.COLUMN_NAME | ForEach-Object { "@" + $_ }))

        

        $saveColumnAssignments = [string]::Join(', ' + [Environment]::NewLine, ($columns.COLUMN_NAME | ForEach-Object { "        @" + $_ + " = @" + $_ }))

        $saveColumnValues = [string]::Join(', ' + [Environment]::NewLine, ($columns.COLUMN_NAME | ForEach-Object { "                { ""@" + $_ + """, record." + $_ + " }"}))

        

        $instanciateArguments = $columnParameters = [string]::Join(',' + [Environment]::NewLine, ($columns | ForEach-Object { "                        row[`"" + $_.COLUMN_NAME +"`"].To" + (ConvertTo-PascalCase -InputText (Get-DBColumnDotNetDataType $_)) +"()" }))


             */

//        var template = $@"
//public class {className}Repository
//{{
//    private readonly IDatabaseAccessor _databaseAccessor;

//    public {className}Repository(IDatabaseAccessor databaseAccessor)
//    {{
//        _databaseAccessor = databaseAccessor;
//    }}

//    public void Clear()
//    {{
//        var sql = @""""EXEC dbo.{tableName}_Clear"""";

//        _databaseAccessor.ExecuteSql(sql);
//    }}

//    public void Save({className} record)
//    {{
//        var sql = @""""
//EXEC dbo.{tableName}_Save 
//{saveColumnAssignments}
//"""";

//        _databaseAccessor.ExecuteSql(sql, new Dictionary<string, object>{{
//{saveColumnValues}
//}});

//    }}

//    public $($tablename)[] GetList() 
//    {{
//        var sql = @""""
//SELECT {columnNames}
//  FROM {databaseObjectSchema}.{tableName}
//"""";

//        var daten = _databaseAccessor.LoadDataTable(sql);
//        return daten.ToInstancesOf(Instanciate);
//    }}

//    private {className} Instanciate(DataRow row) 
//    {{
//        return new {className}(
//$($instanciateArguments)
//        );
//    }}
//}}
//        ";

        var template = "";
        return template;
    }
}


public class DataTransferObjectCSharpCodeAction : CSharpCodeAction
{

    public DataTransferObjectCSharpCodeAction() : 
        base("C# DTO")
    {
    }

    public override string Execute(
        string connectionString, 
        string database, 
        string databaseObjectSchema, 
        string databaseObjectName,
        DatabaseObjectTypeEnum? databaseObjectTypeEnum)
    {
        var databaseAccessor = new DatabaseAccessor(connectionString, database);
        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

        if (databaseObjectTypeEnum != DatabaseObjectTypeEnum.Table &&
            databaseObjectTypeEnum != DatabaseObjectTypeEnum.View)
        {
            return "";
        }

        var className = DotNetClassName(databaseObjectName);
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

        var template = $@"
public class {className}
{{
{columnParameters}

    public {className}(
{columnArguments}
    )
    {{
{parameterAssignment}
    }}
}}
        ";

        return template;
    }

    
}
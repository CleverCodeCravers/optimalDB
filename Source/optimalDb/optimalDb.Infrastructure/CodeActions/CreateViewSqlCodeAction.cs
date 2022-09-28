using optimalDb.BL;

namespace optimalDb.Infrastructure.CodeActions;

public class CreateViewSqlCodeAction : SqlCodeAction
{
    public CreateViewSqlCodeAction() :
        base("CREATE VIEW")
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

        var columns = schemaRepository.GetColumnList(databaseObjectSchema, databaseObjectName);

        var columnsAsCommaList = 
            string.Join(", " + Environment.NewLine,
                columns.Select(x => "           " + x.ColumnName).ToArray()).Trim(); 

        var template = $@"
CREATE VIEW [dbo].{databaseObjectName}
    AS
    SELECT {columnsAsCommaList} 
      FROM [{databaseObjectSchema}].[{databaseObjectName}]
";

        return template;
    }
}
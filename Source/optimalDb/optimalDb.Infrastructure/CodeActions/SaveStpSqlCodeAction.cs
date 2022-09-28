using optimalDb.BL;

namespace optimalDb.Infrastructure.CodeActions;

public class SaveStpSqlCodeAction : SqlCodeAction
{
    public SaveStpSqlCodeAction() :
        base("CREATE Save STP")
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

        var columns = schemaRepository.GetColumnList(databaseObjectSchema, databaseObjectName);

        var columnsAsCommaList =
            string.Join(", " + Environment.NewLine,
                columns.Select(x => "           " + x.ColumnName).ToArray());

        var columnsAsParameterCommaList =
            string.Join(", " + Environment.NewLine,
                columns.Select(x => "           @" + x.ColumnName).ToArray());

        var updateParameterAssignment =
            string.Join(", " + Environment.NewLine,
                columns.Select(x => $"           {x.ColumnName} = @" + x.ColumnName).ToArray()).Trim();

        var stpParameters =
            string.Join(", " + Environment.NewLine,
                columns.Select(x => "           @" + x.ColumnName + " " + SqlDataType(x).ToUpper()).ToArray());

        var template = $@"
CREATE PROCEDURE [dbo].[{databaseObjectName}_Save](
{stpParameters}
        )
    AS
BEGIN
    IF (@Id <= 0)
    BEGIN
        INSERT INTO [{databaseObjectSchema}].[{databaseObjectName}] (
{columnsAsCommaList}
        ) VALUES (
{columnsAsParameterCommaList}
        );

        RETURN
    END

    UPDATE [{databaseObjectSchema}].[{databaseObjectName}]
       SET {updateParameterAssignment}
     WHERE Id = @Id
END
";

        return template;
    }
}
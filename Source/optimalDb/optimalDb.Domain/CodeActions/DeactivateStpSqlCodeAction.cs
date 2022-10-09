using optimalDb.Contracts;
using optimalDb.Persistence;

namespace optimalDb.Domain.CodeActions;

public class DeactivateStpSqlCodeAction : SqlCodeAction
{
    public DeactivateStpSqlCodeAction() :
        base("CREATE Deactivate STP")
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

        var stpParameter = GetPrimaryKeysAsStoredProcedureParameters(schemaRepository, databaseObjectSchema, databaseObjectName);

        var ifAssignments = GetPrimaryKeysAsIfConditions(schemaRepository, databaseObjectSchema, databaseObjectName);

        var whereAssignments = GetPrimaryKeysAsWhereAssignments(schemaRepository, databaseObjectSchema, databaseObjectName);

        var template = $@"
CREATE PROCEDURE [dbo].[{databaseObjectName}_Deactivate]({stpParameter})
    AS
BEGIN
    IF ({ifAssignments})
    BEGIN
        RETURN
    END

    UPDATE [{databaseObjectSchema}].[{databaseObjectName}]
       SET IstAktiv = 0
     WHERE {whereAssignments}
END
";

        return template;
    }
}
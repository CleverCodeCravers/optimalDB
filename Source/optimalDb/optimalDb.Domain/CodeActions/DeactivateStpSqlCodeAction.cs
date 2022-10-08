using optimalDb.Contracts;

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
        var template = $@"
CREATE PROCEDURE [dbo].[{databaseObjectName}_Deactivate](@Id INT)
    AS
BEGIN
    IF (@Id <= 0)
    BEGIN
        RETURN
    END

    UPDATE [{databaseObjectSchema}].[{databaseObjectName}]
       SET IstAktiv = 0
     WHERE Id = @Id
END
";

        return template;
    }
}
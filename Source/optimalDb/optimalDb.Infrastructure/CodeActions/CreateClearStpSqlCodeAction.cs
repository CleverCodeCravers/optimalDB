using optimalDb.BL;

namespace optimalDb.Infrastructure.CodeActions;

public class CreateClearStpSqlCodeAction : SqlCodeAction
{
    public CreateClearStpSqlCodeAction() :
        base("CLEAR STP")
    {
    }

    public override string Execute(
        string connectionString,
        string database,
        string databaseObjectSchema,
        string databaseObjectName,
        DatabaseObjectTypeEnum? databaseObjectTypeEnum)
    {
        var template = $@"
CREATE PROCEDURE [dbo].{databaseObjectName}_Clear
    AS
BEGIN
    TRUNCATE TABLE [{databaseObjectSchema}].[{databaseObjectName}]
END
";

        return template;
    }
}
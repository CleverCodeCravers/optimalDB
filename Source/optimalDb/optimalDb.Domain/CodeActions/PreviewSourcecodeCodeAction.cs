using optimalDb.Contracts;

namespace optimalDb.Domain.CodeActions;

public class PreviewSourcecodeCodeAction : CodeAction
{
    public PreviewSourcecodeCodeAction() : base("Preview Code")
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
        if (databaseObjectTypeEnum == DatabaseObjectTypeEnum.Table)
        {
            return "Code Preview not available for Tables";
        }

        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

        return schemaRepository.GetCode(databaseObjectSchema + "." + databaseObjectName);
    }
}
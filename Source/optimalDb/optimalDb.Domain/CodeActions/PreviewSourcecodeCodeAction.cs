namespace optimalDb.Domain.CodeActions;

public class PreviewSourcecodeCodeAction : CodeAction
{
    public PreviewSourcecodeCodeAction() : base("Preview Code")
    {
    }

    public override string Execute(string connectionString, string database, string databaseObjectSchema,
        string databaseObjectName, DatabaseObjectTypeEnum? databaseObjectTypeEnum)
    {
        if (databaseObjectTypeEnum == DatabaseObjectTypeEnum.Table)
        {
            return "Code Preview not available for Tables";
        }

        var databaseAccessor = new DatabaseAccessor(connectionString, database);
        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

        return schemaRepository.GetCode(databaseObjectSchema + "." + databaseObjectName);
    }
}
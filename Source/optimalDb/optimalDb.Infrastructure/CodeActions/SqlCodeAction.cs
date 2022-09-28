using optimalDb.BL;

namespace optimalDb.Infrastructure.CodeActions;

public abstract class SqlCodeAction : CodeAction
{
    protected SqlCodeAction(string name) : base(name)
    {
    }

    public abstract override string Execute(
        string connectionString, 
        string database, 
        string databaseObjectSchema,
        string databaseObjectName,
        DatabaseObjectTypeEnum? databaseObjectTypeEnum);
}
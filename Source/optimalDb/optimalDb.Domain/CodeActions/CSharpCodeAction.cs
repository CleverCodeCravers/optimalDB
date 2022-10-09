using optimalDb.Contracts;

namespace optimalDb.Domain.CodeActions;

public abstract class CSharpCodeAction : CodeAction
{
    protected CSharpCodeAction(string name) : base(name)
    {
    }

    public abstract override string Execute(
        IDatabaseAccessor databaseAccessor, 
        string connectionString, 
        string database, 
        string databaseObjectSchema,
        string databaseObjectName,
        DatabaseObjectTypeEnum? databaseObjectTypeEnum);

    
}
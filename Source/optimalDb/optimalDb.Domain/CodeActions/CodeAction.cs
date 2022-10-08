namespace optimalDb.Domain.CodeActions;

public abstract class CodeAction
{
    public string Name { get; }

    protected CodeAction(string name)
    {
        Name = name;
    }

    public abstract string Execute(string connectionString,
        string database,
        string databaseObjectSchema,
        string databaseObjectName, DatabaseObjectTypeEnum? databaseObjectTypeEnum);

    public override string ToString()
    {
        return Name;
    }
}
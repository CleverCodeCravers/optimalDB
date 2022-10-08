using optimalDb.Contracts;

namespace optimalDb.Domain.CodeActions;

public abstract class SqlCodeAction : CodeAction
{
    protected SqlCodeAction(string name) : base(name)
    {
    }

    public abstract override string Execute(
        IDatabaseAccessor databaseAccessor,
        string connectionString, 
        string database, 
        string databaseObjectSchema,
        string databaseObjectName,
        DatabaseObjectTypeEnum? databaseObjectTypeEnum);

    protected string SqlDataType(DatabaseColumn databaseColumn)
    {
        if (databaseColumn.DataType.ToLower().Contains("varchar"))
        {
            return databaseColumn.DataType + "(" + databaseColumn.CharacterMaximumLength + ")";
        }

        if (databaseColumn.DataType.ToLower() == "decimal")
        {
            return databaseColumn.DataType + "(" + databaseColumn.NumericPrecision + "," + databaseColumn.NumericScale + ")";
        }

        return databaseColumn.DataType;
    }

}
namespace optimalDb.Infrastructure;

public class DatabaseColumn
{
    public string ColumnName { get; }
    public int OrdinalPosition { get; }
    public string? ColumnDefault { get; }
    public bool IsNullable { get; }
    public string DataType { get; }
    public int CharacterMaximumLength { get; }

    public DatabaseColumn(string columnName, int ordinalPosition, string? columnDefault, bool isNullable, string dataType, int characterMaximumLength)
    {
        ColumnName = columnName;
        OrdinalPosition = ordinalPosition;
        ColumnDefault = columnDefault;
        IsNullable = isNullable;
        DataType = dataType;
        CharacterMaximumLength = characterMaximumLength;
    }
}
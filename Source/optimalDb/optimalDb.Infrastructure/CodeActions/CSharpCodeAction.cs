using optimalDb.BL;

namespace optimalDb.Infrastructure.CodeActions;

public abstract class CSharpCodeAction : CodeAction
{
    protected CSharpCodeAction(string name) : base(name)
    {
    }

    public abstract override string Execute(string connectionString, string database, string databaseObjectSchema,
        string databaseObjectName,
        DatabaseObjectTypeEnum? databaseObjectTypeEnum);

    protected string DotNetNameCamelCase(DatabaseColumn databaseColumn)
    {
        var rest = DotNetName(databaseColumn.ColumnName);
        var startsWith = rest[0].ToString().ToLower();
        rest = rest.Remove(0, 1);

        return startsWith + rest;
    }

    private string DotNetName(string databaseColumnColumnName)
    {
        var validChars = "abcdefghijklmnopqrstuvwxyz_1234567890" + "abcdefghijklmnopqrstuvwxyz".ToUpper();
        var result = "";

        foreach (var character in databaseColumnColumnName)
        {
            if (validChars.Contains(character))
                result += character;
        }

        return result;
    }

    protected string DotNetNamePascalCase(DatabaseColumn databaseColumn)
    {
        var rest = DotNetName(databaseColumn.ColumnName);
        var startsWith = rest[0].ToString().ToUpper();
        rest = rest.Remove(0, 1);

        return startsWith + rest;
    }

    protected string DotNetDataType(DatabaseColumn databaseColumn)
    {
        var datatype = databaseColumn.DataType.ToLower();

        if (datatype == "varchar" || datatype == "nvarchar")
            return "string";
        if (datatype == "bit")
            return "bool";
        if (datatype == "datetime")
            return "DateTime";

        return datatype;
    }

    protected string DotNetClassName(string databaseObjectName)
    {
        return databaseObjectName;
    }
}
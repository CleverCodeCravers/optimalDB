using optimalDb.Contracts;

namespace optimalDb.Domain.CodeActions;

public static class NamingHelper
{
    public static string DotNetNameCamelCase(DatabaseColumn databaseColumn)
    {
        if (databaseColumn == null)
            return ""; 

        var rest = DotNetName(databaseColumn.ColumnName);
        var startsWith = rest[0].ToString().ToLower();
        rest = rest.Remove(0, 1);

        return startsWith + rest;
    }

    public static string DotNetName(string databaseColumnColumnName)
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

    public static string DotNetNamePascalCase(DatabaseColumn databaseColumn)
    {
        var rest = DotNetName(databaseColumn.ColumnName);
        var startsWith = rest[0].ToString().ToUpper();
        rest = rest.Remove(0, 1);

        return startsWith + rest;
    }

    public static string PascalCase(string name)
    {
        var rest = name;
        var startsWith = rest[0].ToString().ToUpper();
        rest = rest.Remove(0, 1);

        return startsWith + rest;
    }

    public static string DotNetDataType(DatabaseColumn databaseColumn)
    {
        var datatype = databaseColumn.DataType.ToLower();

        if (datatype == "varchar" || datatype == "nvarchar")
            return "string";

        if (datatype == "bit")
            return MaybeWithNullable("bool", databaseColumn.IsNullable);

        if (datatype == "datetime")
            return MaybeWithNullable("DateTime", databaseColumn.IsNullable);

        if (datatype == "bigint")
            return MaybeWithNullable("long", databaseColumn.IsNullable);

        if (datatype == "image" || datatype == "varbinary")
            return "byte[]";

        return datatype;
    }

    public static string MaybeWithNullable(string datatype, bool isNullable)
    {
        if (isNullable)
            return datatype + "?";
        return datatype;
    }

    public static string DotNetClassName(string databaseObjectName)
    {
        return databaseObjectName;
    }

    public static string ConverterToDotNetName(DatabaseColumn databaseColumn)
    {
        var nullable = "";
        if (databaseColumn.IsNullable)
            nullable = "Nullable";

        return "To" + nullable + PascalCase(DotNetDataType(databaseColumn)) + "()";
    }
}
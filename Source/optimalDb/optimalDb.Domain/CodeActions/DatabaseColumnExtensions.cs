using optimalDb.Contracts;

namespace optimalDb.Domain.CodeActions;

public static class DatabaseColumnExtensions {
    public static string AsCommaListWithNewlines(this DatabaseColumn[] columns)
    {
        return string.Join(", " + Environment.NewLine, 
            columns.Select(x => "           " + x.ColumnName).ToArray());
    }

    public static string AsParameterListWithNewlines(this DatabaseColumn[] columns)
    {
        return string.Join(", " + Environment.NewLine,
            columns.Select(x => "           @" + x.ColumnName).ToArray());
    }    
    
    public static string AsParameters(this DatabaseColumn[] columns)
    {
        return string.Join(", ", columns.Select(x => "@" + x.ColumnName).ToArray());
    }

    public static string AsDotNetName(this DatabaseColumn[] columns)
    {
        return NamingHelper.DotNetNameCamelCase(columns.FirstOrDefault());
    }
    public static string AsSqlName(this DatabaseColumn[] columns)
    {
        return columns.FirstOrDefault()?.ColumnName??"";
    }

    public static string AsDotNetParameters(this DatabaseColumn[] columns)
    {
        return string.Join(", ", columns.Select(x => NamingHelper.DotNetDataType(x) + " " + 
                                                     NamingHelper.DotNetNameCamelCase(x)).ToArray());
    }

    public static string AsUpdateParameterToColumnAssignmentWithNewlines(this DatabaseColumn[] columns)
    {
        return
            string.Join(", " + Environment.NewLine,
                columns.Select(x => $"           {x.ColumnName} = @" + x.ColumnName).ToArray()).Trim();
    }

    public static string AsWhereConditions(this DatabaseColumn[] columns)
    {
        return
            string.Join(" AND " + Environment.NewLine,
                columns.Select(x => $"           {x.ColumnName} = @" + x.ColumnName).ToArray()).Trim();
    }

    public static string AsStoredProcedureParameters(this DatabaseColumn[] columns)
    {
        return
            string.Join(", " + Environment.NewLine, 
                columns.Select(x => "            @" + x.ColumnName + " " + SqlDataType(x)).ToArray()).Trim();
    }

    private static string SqlDataType(DatabaseColumn databaseColumn)
    {
        if (databaseColumn.DataType.ToLower().Contains("varchar"))
        {
            if (databaseColumn.CharacterMaximumLength == -1)
                return databaseColumn.DataType + "(MAX)";

            return databaseColumn.DataType + "(" + databaseColumn.CharacterMaximumLength + ")";
        }

        if (databaseColumn.DataType.ToLower() == "decimal")
        {
            return databaseColumn.DataType + "(" + databaseColumn.NumericPrecision + "," + databaseColumn.NumericScale + ")";
        }

        return databaseColumn.DataType;
    }
}
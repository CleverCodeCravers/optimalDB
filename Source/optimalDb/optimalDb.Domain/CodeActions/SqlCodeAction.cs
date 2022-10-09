using optimalDb.Contracts;
using optimalDb.Persistence;

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
            if ( databaseColumn.CharacterMaximumLength == -1 )
                return databaseColumn.DataType + "(MAX)";

            return databaseColumn.DataType + "(" + databaseColumn.CharacterMaximumLength + ")";
        }

        if (databaseColumn.DataType.ToLower() == "decimal")
        {
            return databaseColumn.DataType + "(" + databaseColumn.NumericPrecision + "," + databaseColumn.NumericScale + ")";
        }

        return databaseColumn.DataType;
    }

    protected string GetPrimaryKeysAsStoredProcedureParameters(
        DatabaseSchemaRepository schemaRepository,
        string databaseObjectSchema,
        string databaseObjectName
    )
    {

        var columns = schemaRepository.GetPrimaryKeyList(databaseObjectSchema, databaseObjectName);

        var stpParameter =
            string.Join(", ", columns.Select(x => "@" + x.ColumnName + " " + SqlDataType(x)).ToArray()).Trim();

        return stpParameter;
    }
    protected string GetPrimaryKeysAsIfConditions(
        DatabaseSchemaRepository schemaRepository,
        string databaseObjectSchema,
        string databaseObjectName
    )
    {

        var columns = schemaRepository.GetPrimaryKeyList(databaseObjectSchema, databaseObjectName);

        var ifAssignments =
            string.Join(" AND ", columns.Select(x => "@" + x.ColumnName + " <= 0").ToArray()).Trim();

        return ifAssignments;
    }

    protected string GetPrimaryKeysAsWhereAssignments(
        DatabaseSchemaRepository schemaRepository,
        string databaseObjectSchema,
        string databaseObjectName
    )
    {

        var columns = schemaRepository.GetPrimaryKeyList(databaseObjectSchema, databaseObjectName);

        return string.Join(" AND ", columns.Select(x => x.ColumnName + " = @" + x.ColumnName).ToArray()).Trim();
    }

}
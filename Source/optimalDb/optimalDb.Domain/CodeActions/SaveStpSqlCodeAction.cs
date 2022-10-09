using optimalDb.Contracts;
using optimalDb.Persistence;

namespace optimalDb.Domain.CodeActions;

public class SaveStpSqlCodeAction : SqlCodeAction
{
    public SaveStpSqlCodeAction() :
        base("CREATE Save STP")
    {
    }

    public override string Execute(
        IDatabaseAccessor databaseAccessor,
        string connectionString,
        string database,
        string databaseObjectSchema,
        string databaseObjectName,
        DatabaseObjectTypeEnum? databaseObjectTypeEnum)
    {
        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

        var allColumns = schemaRepository.GetColumnsIncludingPrimaryKeys(databaseObjectSchema, databaseObjectName);
        var primaryKeys = schemaRepository.GetPrimaryKeyList(databaseObjectSchema, databaseObjectName);
        var allColumnsWithoutPrimaryKeys = schemaRepository.GetColumnList(databaseObjectSchema, databaseObjectName);

        var insertColumnList = allColumnsWithoutPrimaryKeys.AsCommaListWithNewlines();

        var insertColumnListAsParameters = allColumnsWithoutPrimaryKeys.AsParameterListWithNewlines();
        var primaryKeyName = primaryKeys.AsParameters();

        var updateParameterAssignment = allColumnsWithoutPrimaryKeys.AsUpdateParameterToColumnAssignmentWithNewlines();
        var updateWhere = primaryKeys.AsWhereConditions();

        var stpParameters = allColumns.AsStoredProcedureParameters();

        var template = $@"
CREATE PROCEDURE [dbo].[{databaseObjectName}_Save](
            {stpParameters}
        )
    AS
BEGIN
    IF ({primaryKeyName} <= 0)
    BEGIN
        INSERT INTO [{databaseObjectSchema}].[{databaseObjectName}] (
{insertColumnList}
        ) VALUES (
{insertColumnListAsParameters}
        );

        SELECT SCOPE_IDENTITY() AS Id

        RETURN
    END

    UPDATE [{databaseObjectSchema}].[{databaseObjectName}]
       SET {updateParameterAssignment}
     WHERE {updateWhere}

    SELECT {primaryKeyName} AS Id
END
";

        return template;
    }
}
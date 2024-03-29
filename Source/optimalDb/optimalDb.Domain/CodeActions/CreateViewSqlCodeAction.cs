﻿using optimalDb.Contracts;
using optimalDb.Persistence;

namespace optimalDb.Domain.CodeActions;

public class CreateViewSqlCodeAction : SqlCodeAction
{
    public CreateViewSqlCodeAction() :
        base("CREATE VIEW")
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

        var columns = schemaRepository.GetColumnsIncludingPrimaryKeys(databaseObjectSchema, databaseObjectName);

        var columnsAsCommaList = 
            string.Join(", " + Environment.NewLine,
                columns.Select(x => "           " + x.ColumnName).ToArray()).Trim(); 

        var template = $@"
CREATE VIEW [dbo].{databaseObjectName}
    AS
    SELECT {columnsAsCommaList} 
      FROM [{databaseObjectSchema}].[{databaseObjectName}]
";

        return template;
    }
}
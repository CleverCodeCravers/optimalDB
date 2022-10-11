using optimalDb.Contracts;
using optimalDb.Persistence;

namespace optimalDb.Interactors;

public class SqlCodeSearchIndexer
{
    public IDatabaseObjectWithCode[] IndexEverythingThroughConnection(string connectionString)
    {
        var databaseAccessor = new DatabaseAccessor(connectionString);
        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);
        var databases = schemaRepository.GetDatabaseList();
        var result = new List<IDatabaseObjectWithCode>();

        foreach (var database in databases)
        {
            result.AddRange(IndexDatabase(connectionString, database));
        }

        return result.ToArray();
    }

    public IDatabaseObjectWithCode[] IndexDatabase(string connectionString, string database)
    {
        var databaseAccessor = new DatabaseAccessor(connectionString, database);
        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

        var result = new List<IDatabaseObjectWithCode>();

        result.AddRange(AddCodeToObject(schemaRepository.GetViewList(), schemaRepository));
        result.AddRange(AddCodeToObject(schemaRepository.GetFunctionList(), schemaRepository));
        result.AddRange(AddCodeToObject(schemaRepository.GetStoredProcedureList(), schemaRepository));

        return result.ToArray();
    }

    private IDatabaseObjectWithCode[] AddCodeToObject(DatabaseObject[] databaseObjects, DatabaseSchemaRepository schemaRepository)
    {
        var result = new List<IDatabaseObjectWithCode>();

        foreach (var databaseObject in databaseObjects)
        {
            result.Add(
                new DatabaseObjectWithCode(
                    databaseObject.Schema,
                    databaseObject.Name,
                    databaseObject.Fullname,
                    schemaRepository.GetCode(databaseObject.Fullname)
                ));
        }

        return result.ToArray();
    }
}
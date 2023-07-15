//using optimalDb.Contracts;
//using optimalDb.Persistence;

//namespace optimalDb.Interactors;

//public class SqlCodeSearchIndexer
//{
//    public IDatabaseObjectWithCode[] IndexEverythingThroughConnection(string connectionString)
//    {
//        var databaseAccessor = new DatabaseAccessor(connectionString);
//        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);
//        var databases = schemaRepository.GetDatabaseList();
//        var result = new List<IDatabaseObjectWithCode>();

//        foreach (var database in databases)
//        {
//            result.AddRange(IndexDatabase(connectionString, database));
//        }

//        return result.ToArray();
//    }

//    public IDatabaseObjectWithCode[] IndexDatabase(string connectionString, string database)
//    {
//        var databaseAccessor = new DatabaseAccessor(connectionString, database);
//        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

//        var result = new List<IDatabaseObjectWithCode>();

//        result.AddRange(AddCodeToObject(schemaRepository.GetViewList(), schemaRepository));
//        result.AddRange(AddCodeToObject(schemaRepository.GetFunctionList(), schemaRepository));
//        result.AddRange(AddCodeToObject(schemaRepository.GetStoredProcedureList(), schemaRepository));

//        return result.ToArray();
//    }

//    private IDatabaseObjectWithCode[] AddCodeToObject(DatabaseObject[] databaseObjects, DatabaseSchemaRepository schemaRepository)
//    {
//        var result = new List<IDatabaseObjectWithCode>();

//        foreach (var databaseObject in databaseObjects)
//        {
//            result.Add(
//                new DatabaseObjectWithCode(
//                    databaseObject.Schema,
//                    databaseObject.Name,
//                    databaseObject.Fullname,
//                    schemaRepository.GetCode(databaseObject.Fullname)
//                    ));
//        }

//        return result.ToArray();
//    }
//}


//public class SqlCodeSearchInteractor
//{
//    private readonly IDatabaseObjectWithCode[] _databaseObjects;

//    public SqlCodeSearchInteractor(IDatabaseObjectWithCode[] databaseObjects)
//    {
//        _databaseObjects = databaseObjects;
//    }

//    public IDatabaseObjectWithCode[] SearchFor(string query)
//    {
//        var queryParts = query.ToLower().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
//        var result = new List<IDatabaseObjectWithCode>();

//        foreach (var databaseObject in _databaseObjects)
//        {
//            if (IsFulltextMatch(queryParts, databaseObject.Code))
//            {
//                result.Add(databaseObject);
//            }
//        }

//        return result.ToArray();
//    }

//    private bool IsFulltextMatch(string[] queryParts, string databaseObjectCode)
//    {
//        var codeInLowercase = databaseObjectCode.ToLower().Trim();

//        foreach (var part in queryParts)
//        {
//            if (!codeInLowercase.Contains(part))
//                return false;
//        }

//        return true;
//    }
//}
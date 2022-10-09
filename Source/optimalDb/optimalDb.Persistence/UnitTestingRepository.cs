using optimalDb.Contracts;

namespace optimalDb.Persistence;

public class UnitTestingRepository : IUnitTestingRepository
{
    private readonly DatabaseSchemaRepository _schemaRepository;
    private readonly string _connectionString;

    public UnitTestingRepository(DatabaseSchemaRepository schemaRepository,
        string connectionString)
    {
        _schemaRepository = schemaRepository;
        _connectionString = connectionString;
    }

    public UnitTest[] DiscoverTests()
    {
        var result = new List<UnitTest>();
        var databases = _schemaRepository.GetDatabaseList();

        foreach (var database in databases)
        {
            result.AddRange(DiscoverTestsInDatabase(_connectionString, database));
        }

        return result.ToArray();
    }

    private UnitTest[] DiscoverTestsInDatabase(string connectionString, string database)
    {
        var connectionStringModifier = new ConnectionStringModifier(connectionString);
        var specificConnectionString = connectionStringModifier.ChangeDatabaseTo(database);

        var databaseAccessor = new DatabaseAccessor(connectionString, database);
        var schemaRepository = new DatabaseSchemaRepository(databaseAccessor);

        var storedProcedures = schemaRepository.GetStoredProcedureList();

        var sqlUnitTests = storedProcedures.Where(x => x.Name.StartsWith("TEST_")).ToArray();

        return sqlUnitTests.Select(x => new UnitTest(
            Guid.NewGuid(),
            specificConnectionString,
            x.Schema,
            x.Name
        )).ToArray();
    }
}
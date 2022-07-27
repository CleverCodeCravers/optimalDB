using optimalDb.Interfaces;

namespace optimalDb.BL;
public class DatabaseConnection : IDatabaseConnection
{
    public string Name { get; }
    public string ConnectionString { get; }

    public DatabaseConnection(string name, string connectionString)
    {
        Name = name;
        ConnectionString = connectionString;
    }
}

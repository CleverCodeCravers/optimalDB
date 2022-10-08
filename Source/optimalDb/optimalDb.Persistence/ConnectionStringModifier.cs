namespace optimalDb.Persistence;

public class ConnectionStringModifier
{
    private readonly string _connectionString;

    public ConnectionStringModifier(string connectionString)
    {
        _connectionString = connectionString;
    }

    public string ChangeDatabaseTo(string? database)
    {
        if (string.IsNullOrWhiteSpace(database))
            return _connectionString;

        var parts = _connectionString.Split(";", StringSplitOptions.RemoveEmptyEntries);
        
        for (var i = 0; i < parts.Length; i++)
        {
            if (parts[i].ToLower().StartsWith("database="))
            {
                parts[i] = "Database=" + database;
            }
        }

        return string.Join(";", parts);
    }
}
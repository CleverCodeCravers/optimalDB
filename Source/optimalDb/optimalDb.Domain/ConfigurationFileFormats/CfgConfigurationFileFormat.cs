namespace optimalDb.Domain.ConfigurationFileFormats;

public class CfgConfigurationFileFormat : IConfigurationFileFormat
{
    public string Name { get; }
    public string FileExtension { get; }
    public DatabaseConnection[]? Load(string fileName)
    {
        var content = File.ReadAllLines(fileName);
        var result = new List<DatabaseConnection>();

        foreach (var line in content)
        {
            var key = "ConnectionString|";
            // Connection Strings 
            if (line.StartsWith(key) && IsSqlServerConnectionString(line))
            {
                var lineWithoutKey = line.Remove(0, key.Length);
                
                var split = lineWithoutKey.Split('=', 2, StringSplitOptions.None);
                if (split.Length == 2)
                {
                    result.Add(new DatabaseConnection(split[0], split[1]));
                }
            }
        }

        return result.ToArray();
    }

    private bool IsSqlServerConnectionString(string line)
    {
        var lowercase = line.ToLower();
        if (lowercase.Contains("trusted_connection"))
            return true;
        if (lowercase.Contains("user"))
            return true;
        return false;
    }

    public void Save(string fileName, DatabaseConnection[] localConnections)
    {
        throw new Exception("Saving this format is not possible.");
    }

    public CfgConfigurationFileFormat()
    {
        Name = "CFG Format";
        FileExtension = "*.cfg";
    }
}

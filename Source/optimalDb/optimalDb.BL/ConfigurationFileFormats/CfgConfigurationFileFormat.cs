using optimalDb.Interfaces;

namespace optimalDb.BL.ConfigurationFileFormats;

public class CfgConfigurationFileFormat : IConfigurationFileFormat
{
    public string Name { get; }
    public string FileExtension { get; }
    public IDatabaseConnection[]? Load(string fileName)
    {
        var content = File.ReadAllLines(fileName);
        var result = new List<IDatabaseConnection>();

        foreach (var line in content)
        {
            var key = "ConnectionString|";
            if (line.StartsWith(key))
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

    public void Save(string fileName, IDatabaseConnection[] localConnections)
    {
        throw new Exception("Saving this format is not possible.");
    }

    public CfgConfigurationFileFormat()
    {
        Name = "CFG Format";
        FileExtension = "*.cfg";
    }
}

using Newtonsoft.Json;
using optimalDb.Contracts;

namespace optimalDb.Domain.ConfigurationFileFormats;

public class JsonConfigurationFileFormat : IConfigurationFileFormat
{
    public string Name { get; }
    public string FileExtension { get; }
    public DatabaseConnection[]? Load(string fileName)
    {
        var content = File.ReadAllText(fileName);
        var data = JsonConvert.DeserializeObject<DatabaseConnection[]>(content);
        return data;
    }

    public void Save(string fileName, DatabaseConnection[] localConnections)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(localConnections);
        File.WriteAllText(fileName, json);
    }

    public JsonConfigurationFileFormat()
    {
        Name = "Json Config Format";
        FileExtension = "*.json";
    }
}
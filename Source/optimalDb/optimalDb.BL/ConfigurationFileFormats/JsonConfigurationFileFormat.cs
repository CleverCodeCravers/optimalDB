using System.Text.Json.Serialization;
using Newtonsoft.Json;
using optimalDb.Interfaces;

namespace optimalDb.BL.ConfigurationFileFormats;

public class JsonConfigurationFileFormat : IConfigurationFileFormat
{
    public string Name { get; }
    public string FileExtension { get; }
    public IDatabaseConnection[]? Load(string fileName)
    {
        var content = File.ReadAllText(fileName);
        var data = JsonConvert.DeserializeObject<DatabaseConnection[]>(content);
        var asInterfaces = data?.Select(x => x as IDatabaseConnection).ToArray();
        return asInterfaces;
    }

    public void Save(string fileName, IDatabaseConnection[] localConnections)
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
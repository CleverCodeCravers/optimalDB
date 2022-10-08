namespace optimalDb.Domain;

public interface IConfigurationFileFormat
{
    string Name { get; }
    string FileExtension { get; }
    DatabaseConnection[]? Load(string fileName);
    void Save(string fileName, DatabaseConnection[] localConnections);
}


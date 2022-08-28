namespace optimalDb.Interfaces;

public interface IConfigurationFileFormat
{
    string Name { get; }
    string FileExtension { get; }
    IDatabaseConnection[]? Load(string fileName);
    void Save(string fileName, IDatabaseConnection[] localConnections);
}


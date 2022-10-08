namespace optimalDb.Domain.ConfigurationFileFormats;

public static class ConfigurationFileFormatFactory
{
    public static ConfigurationFileFormatCollection GetAllFileFormats()
    {
        return 
            new ConfigurationFileFormatCollection(
                new IConfigurationFileFormat?[]
                {
                    new CfgConfigurationFileFormat(),
                    new JsonConfigurationFileFormat()
                });
    }
}
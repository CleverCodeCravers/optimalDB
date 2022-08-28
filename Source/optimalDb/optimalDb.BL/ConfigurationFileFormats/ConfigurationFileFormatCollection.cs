using System.Text;
using optimalDb.Interfaces;

namespace optimalDb.BL.ConfigurationFileFormats;

public class ConfigurationFileFormatCollection
{
    private readonly IConfigurationFileFormat?[] _formats;

    public ConfigurationFileFormatCollection(IConfigurationFileFormat?[] formats)
    {
        _formats = formats;
    }

    public string FilterForDialogs()
    {
        var result = new StringBuilder();

        foreach (var format in _formats)
        {
            if (result.Length > 0)
                result.Append("|");

            result.Append(format?.Name.Replace("|", ""));
            result.Append("|");
            result.Append(format?.FileExtension);
        }

        return result.ToString();
    }

    public IConfigurationFileFormat? GetMatchingFormatFor(string fileName)
    {
        foreach (var format in _formats)
        {
            var extension = format?.FileExtension.Replace("*", "");
            if (fileName.EndsWith(extension??""))
            {
                return format;
            }
        }

        return null;
    }
}
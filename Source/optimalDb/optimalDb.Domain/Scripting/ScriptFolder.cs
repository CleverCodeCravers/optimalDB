namespace optimalDb.Domain.Scripting;

public class ScriptFolder
{
    public string FolderPath { get; }

    public ScriptFolder(string folderPath)
    {
        FolderPath = folderPath;
    }

    public string[] GetFiles()
    {
        var directoryInfo = new DirectoryInfo(FolderPath);
        var files = directoryInfo.GetFiles("*.ps1", SearchOption.AllDirectories);
        var result = new List<string>();

        foreach (var file in files)
        {
            result.Add(file.FullName);
        }

        return result.ToArray();
    }
}


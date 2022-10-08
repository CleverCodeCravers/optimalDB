using System.Diagnostics;

namespace optimalDb.Domain.Scripting;

public static class PowershellScripting
{
    public static string ExecuteScript(
        string scriptFile,
        string connectionString,
        string database,
        string databaseObjectSchema,
        string databaseObjectName
        )
    {
        try
        {
            var output = "";

            Process process = new Process();
            process.StartInfo.FileName = "C:\\Windows\\System32\\WindowsPowershell\\v1.0\\powershell.exe";
            process.StartInfo.Arguments = "-file \"" + scriptFile + "\"" +
                                          " -ConnectionString \"" + connectionString + "\"" +
                                          " -Database \"" + database + "\"" +
                                          " -Schema \"" + databaseObjectSchema + "\"" +
                                          " -ObjectName \"" + databaseObjectName + "\"";

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            output += process.StandardOutput.ReadToEnd();
            output += process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (output.Contains("###OUTPUTSTARTSHERE###"))
            {
                output = output.Split("###OUTPUTSTARTSHERE###", 2)[1];
                var inRows = new List<string>(output.Split("\n"));

                for (var i = inRows.Count - 1; i >= 0; i--)
                {
                    if (string.IsNullOrWhiteSpace(inRows[i].Trim()))
                        inRows.RemoveAt(i);
                }

                return string.Join("\n", inRows.ToArray());
            }

            return output;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}
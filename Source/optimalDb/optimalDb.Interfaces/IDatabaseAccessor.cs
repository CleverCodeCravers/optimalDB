using System.Data;

namespace optimalDb.Interfaces;

public interface IDatabaseAccessor
{
    DataTable LoadDataTable(string sql, Dictionary<string, object> parameters = null, int timeoutInSeconds = 15);
    int Execute(string sql, Dictionary<string, object> parameters, int timeoutInSeconds = 15);
}
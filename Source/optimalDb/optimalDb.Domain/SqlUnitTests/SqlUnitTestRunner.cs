using optimalDb.Contracts;
using optimalDb.Persistence;

namespace optimalDb.Domain.SqlUnitTests;

public class SqlUnitTestRunner : IUnitTestRunner
{
    public UnitTestResult Run(UnitTest test)
    {
        var databaseAccessor = new DatabaseAccessor(test.ConnectionString);
        try
        {
            var result = databaseAccessor.LoadDataTable(
                "EXEC [" + test.Schema + "].[" + test.StoredProcedureName + "]",
                new Dictionary<string, object>());

            if (result.Rows.Count == 0)
            {
                return new UnitTestResult(test, true, "", result);
            }

            return new UnitTestResult(test, false, "There have been problems.", result);

        }
        catch (Exception e)
        {
            return new UnitTestResult(test, false, e.Message, null);
        }
    }
}
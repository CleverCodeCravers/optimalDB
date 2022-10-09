using optimalDb.Contracts;

namespace optimalDb.Interactors.Tests.SqlUnitTests;

class UnitTestRunnerMock : IUnitTestRunner
{
    public UnitTestResult Run(UnitTest test)
    {
        return new UnitTestResult(test, true, "Yey!", null);
    }
}
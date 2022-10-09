using optimalDb.Interactors.Tests;

class UnitTestRunnerMock : IUnitTestRunner
{
    public UnitTestResult Run(UnitTest test)
    {
        return new UnitTestResult(test, true, "Yey!", null);
    }
}
namespace optimalDb.Contracts;

public interface IUnitTestRunner
{
    UnitTestResult Run(UnitTest test);
}
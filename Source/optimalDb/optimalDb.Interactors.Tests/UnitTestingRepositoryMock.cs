namespace optimalDb.Interactors.Tests;

public class UnitTestingRepositoryMock : IUnitTestingRepository
{
    private readonly UnitTest[] _tests;

    public UnitTestingRepositoryMock(UnitTest[] tests)
    {
        _tests = tests;
    }

    public UnitTest[] DiscoverTests()
    {
        return _tests;
    }
}
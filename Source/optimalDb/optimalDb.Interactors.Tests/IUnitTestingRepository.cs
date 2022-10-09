namespace optimalDb.Interactors.Tests;

public interface IUnitTestingRepository
{
    UnitTest[] DiscoverTests();
}
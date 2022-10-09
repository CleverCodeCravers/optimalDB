namespace optimalDb.Contracts;

public interface IUnitTestingRepository
{
    UnitTest[] DiscoverTests();
}
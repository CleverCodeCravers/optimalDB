namespace optimalDb.Interfaces;
public interface IDatabaseConnection
{
    string Name { get; }
    string ConnectionString { get; }
}
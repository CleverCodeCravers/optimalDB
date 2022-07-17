namespace optimalDb.Interfaces;
public interface IDatabaseConnection
{
    string Name { get; }
    string ConnectionString { get; }
}

public interface IViewPerformanceTestResult
{
    string ViewName { get; } // SCHEMA.VIEWNAME
    decimal DurationInSeconds { get; } // 0.5s oder 30s ... 
}
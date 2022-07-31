namespace optimalDb.Interfaces;

public interface IViewPerformanceTestResult
{
    string ViewName { get; } // SCHEMA.VIEWNAME
    decimal? DurationInSeconds { get; } // 0.5s oder 30s ... 
    string ExceptionMessage { get; }
}
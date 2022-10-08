namespace optimalDb.Domain;

public class ViewPerformanceTestResult : IViewPerformanceTestResult
{
    public string ViewName { get; }

    public decimal? DurationInSeconds { get; }

    public string ExceptionMessage { get; }

    public ViewPerformanceTestResult(string viewName, decimal? durationInSeconds, string exceptionMessage = "")
    {
        ViewName = viewName;
        DurationInSeconds = durationInSeconds;
        ExceptionMessage = exceptionMessage;
    }
}
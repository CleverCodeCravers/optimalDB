using optimalDb.Interfaces;

namespace optimalDb.BL;

public class ViewPerformanceTestResult : IViewPerformanceTestResult
{
    public string ViewName { get; }

    public decimal DurationInSeconds { get; }

    public ViewPerformanceTestResult(string viewName, decimal durationInSeconds)
    {
        ViewName = viewName;
        DurationInSeconds = durationInSeconds;
    }
}
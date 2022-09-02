using optimalDb.Interfaces;

namespace optimalDb.BL.TestViewPerformances;

public class MeasureViewPerformanceProcessStep : ProcessStep
{
    private readonly IViewName _viewName;
    private readonly IDatabaseAccessor _databaseAccessor;

    public MeasureViewPerformanceProcessStep(
        IViewName viewName, 
        IDatabaseAccessor databaseAccessor) : 
        base($"Measure view performance of {viewName.Fullname}")
    {
        _viewName = viewName;
        _databaseAccessor = databaseAccessor;
    }

    public override ViewPerformanceTestResult Execute()
    {
        try
        {
            return new ViewPerformanceTestResult(
                _viewName.Fullname,
                GetDurationOfViewExecution(
                    _viewName.Fullname, 
                    _databaseAccessor)
            );
        }
        catch (Exception exception)
        {
            return new ViewPerformanceTestResult(
                _viewName.Fullname,
                null,
                exception.Message
            );
        }
    }

    private decimal? GetDurationOfViewExecution(string viewName, IDatabaseAccessor databaseAccessor )
    {
        DateTime start = DateTime.Now;

        _databaseAccessor.LoadDataTable("SELECT * FROM " + viewName);

        decimal result = (decimal)(DateTime.Now - start).TotalSeconds;
        return decimal.Round(result, 2);
    }
}
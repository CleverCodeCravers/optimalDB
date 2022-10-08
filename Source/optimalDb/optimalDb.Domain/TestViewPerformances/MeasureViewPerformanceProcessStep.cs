namespace optimalDb.Domain.TestViewPerformances;

public class MeasureViewPerformanceProcessStep : ProcessStep
{
    private readonly IDatabaseObject _databaseObject;
    private readonly IDatabaseAccessor _databaseAccessor;

    public MeasureViewPerformanceProcessStep(
        IDatabaseObject databaseObject, 
        IDatabaseAccessor databaseAccessor) : 
        base($"Measure view performance of {databaseObject.Fullname}")
    {
        _databaseObject = databaseObject;
        _databaseAccessor = databaseAccessor;
    }

    public override ViewPerformanceTestResult Execute()
    {
        try
        {
            return new ViewPerformanceTestResult(
                _databaseObject.Fullname,
                GetDurationOfViewExecution(
                    _databaseObject.Fullname, 
                    _databaseAccessor)
            );
        }
        catch (Exception exception)
        {
            return new ViewPerformanceTestResult(
                _databaseObject.Fullname,
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
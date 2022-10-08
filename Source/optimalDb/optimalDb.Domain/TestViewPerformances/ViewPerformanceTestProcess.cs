namespace optimalDb.Domain.TestViewPerformances;

public class ViewPerformanceTestProcess : Process
{
    private readonly IDatabaseAccessor _databaseAccessor;

    public ViewPerformanceTestProcess(
        IDatabaseAccessor databaseAccessor)
    {
        _databaseAccessor = databaseAccessor;
    }


    public override void GenerateProcessSteps()
    {
    }

    public override void Run(Action<string, int> reportProgress, Func<bool> getCancellationPending)
    {
        Results = new List<ViewPerformanceTestResult>();

        for (var i = 0; i < Steps?.Count; i++)
        {
            if (getCancellationPending())
            {
                break;
            }

            var currentStep = Steps?[i];
            int stepCount = (Steps?.Count ?? 0);
            int percentProgress = (i * 100) / stepCount;

            reportProgress(currentStep?.Name??"-", percentProgress);
            
            var result = Steps?[i].Execute();
            if (result != null)
                Results.Add(result);
        }
    }
}
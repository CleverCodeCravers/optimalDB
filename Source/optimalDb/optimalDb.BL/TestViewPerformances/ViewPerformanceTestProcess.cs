using optimalDb.Interfaces;

namespace optimalDb.BL.TestViewPerformances;

public class ViewPerformanceTestProcess : Process
{
    private readonly IDatabaseSchemaRepository _schemaRepository;
    private readonly IDatabaseAccessor _databaseAccessor;

    public ViewPerformanceTestProcess(
        IDatabaseSchemaRepository schemaRepository,
        IDatabaseAccessor databaseAccessor)
    {
        _schemaRepository = schemaRepository;
        _databaseAccessor = databaseAccessor;
    }


    public override void GenerateProcessSteps()
    {
        Steps = new List<ProcessStep>();

        var views = _schemaRepository.GetViewList();

        foreach (var view in views)
        {
            Steps.Add(new MeasureViewPerformanceProcessStep(view, _databaseAccessor));
        }
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
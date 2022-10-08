namespace optimalDb.Domain.TestViewPerformances;

public abstract class Process
{
    public List<ProcessStep>? Steps { get; set; }
    public List<ViewPerformanceTestResult>? Results { get; protected set; }

    public int Length => Steps?.Count ?? 0;

    public abstract void GenerateProcessSteps();

    public abstract void Run(Action<string, int> reportProgress, Func<bool> getCancellationPending);
}
namespace optimalDb.BL.TestViewPerformances;

public abstract class ProcessStep
{
    public string Name { get; }

    protected ProcessStep(string name)
    {
        Name = name;
    }

    public abstract ViewPerformanceTestResult Execute();
}
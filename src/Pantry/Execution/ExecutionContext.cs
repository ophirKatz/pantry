namespace Pantry.Execution;

public class ExecutionContext
{
    public ExecutionContext(bool dryRun)
    {
        DryRun = dryRun;
    }

    public bool DryRun { get; }
}
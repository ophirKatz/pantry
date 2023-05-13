namespace Pantry.Execution;

internal class ExecutionEngine
{
    private readonly AggregateRecipe _aggregateRecipe;
    private readonly Instructions _instructions;

    public ExecutionEngine(AggregateRecipe aggregateRecipe, Instructions instructions)
    {
        _aggregateRecipe = aggregateRecipe;
        _instructions = instructions;
    }

    public async Task ExecuteAsync(ExecutionContext context)
    {
        _aggregateRecipe.Prepare(_instructions);
        // TODO : Build graph from InstructionDescriptors
        // TODO : Execute graph
    }
}
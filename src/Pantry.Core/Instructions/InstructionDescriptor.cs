namespace Pantry.Core.Instructions;

public record InstructionDescriptor(Instruction Instruction) : IInstructionOrders
{
    public List<string> RunAfter { get; } = new();
    public List<string> RunBefore { get; } = new();

    public IInstructionOrders After(string name)
    {
        RunAfter.Add(name);
        return this;
    }

    public IInstructionOrders Before(string name)
    {
        RunBefore.Add(name);
        return this;
    }
}
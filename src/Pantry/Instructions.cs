namespace Pantry;

public class Instructions
{
    private readonly IInstructionFactory _instructionFactory;

    public Instructions(IInstructionFactory instructionFactory)
    {
        _instructionFactory = instructionFactory;
    }

    private readonly List<InstructionDescriptor> _descriptors = new();

    public IReadOnlyList<InstructionDescriptor> InstructionDescriptors => _descriptors.AsReadOnly();

    public IInstructionOrders AddInstruction(string name, Action<Download.Download> optionsBuildAction)
    {
        var instruction = _instructionFactory.Create<Download.Download>(name);
        optionsBuildAction(instruction);
        var descriptor = new InstructionDescriptor(instruction);
        _descriptors.Add(descriptor);
        return descriptor;
    }
}
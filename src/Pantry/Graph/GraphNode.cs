namespace Pantry.Graph;

internal class GraphNode
{
    public static GraphNode FromDescriptor(InstructionDescriptor descriptor)
        => new(descriptor.Instruction);

    public GraphNode(Instruction instruction)
    {
        Instruction = instruction;
    }

    public Instruction Instruction { get; }
    public string Name => Instruction.Name;
}
namespace Pantry;

public static class InstructionsExtensions
{
    public static IInstructionOrders Download(this Instructions actions, string name, Action<Download.Download> options)
    {
        return actions.AddInstruction(name, options);
    }
}
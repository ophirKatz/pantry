using Pantry.Core.Instructions;

namespace Pantry;

public static class InstructionsExtensions
{
    public static IInstructionOrders Download(this Instructions actions, string name, Action<Download> options)
    {
        return actions.AddInstruction(name, options);
    }
}
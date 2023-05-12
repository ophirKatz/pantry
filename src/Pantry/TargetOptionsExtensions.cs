using Pantry.Core.Instructions;

namespace Pantry;

public static class TargetOptionsExtensions
{
    public static IInstructionOrders<TTarget> WithDescription<TTarget>(this IInstructionOrders<TTarget> builderBuilder, string description)
        where TTarget : Instruction
    {
        return builderBuilder.Configure(x => x.Description = description);
    }
}
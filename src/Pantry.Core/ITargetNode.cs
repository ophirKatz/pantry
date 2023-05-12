using Pantry.Core.Instructions;

namespace Pantry;

public sealed record TargetNodeDefinitions(
    Instruction Instruction,
    IReadOnlyList<string> RunBefore,
    IReadOnlyList<string> RunAfter
);

public interface ITargetNodeDefinitionsBuilder
{
    TargetNodeDefinitions Build();
}
namespace Pantry;

public sealed record TargetNodeDefinitions(
    Target Target,
    IReadOnlyList<string> RunBefore,
    IReadOnlyList<string> RunAfter
);

public interface ITargetNodeDefinitionsBuilder
{
    TargetNodeDefinitions Build();
}
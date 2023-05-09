namespace Pantry;

public class TargetActions
{
    private readonly List<ITargetNodeDefinitionsBuilder> _targets = new();

    public IReadOnlyList<ITargetNodeDefinitionsBuilder> Targets => _targets.AsReadOnly();

    public ITargetOptionsBuilder<TTarget> Target<TTarget>(string name) where TTarget : Target, new()
    {
        var options = new TargetOptionsBuilder<TTarget>(name);
        _targets.Add(options);
        return options;
    }
}
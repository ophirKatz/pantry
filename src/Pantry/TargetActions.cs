namespace Pantry;

public class TargetActions
{
    private readonly List<ITargetOptions> _targets = new();

    public IReadOnlyList<ITargetOptions> Targets => _targets.AsReadOnly();

    public ITargetOptions<TTarget> Target<TTarget>(string name) where TTarget : Target
    {
        var options = new TargetOptions<TTarget>(name);
        _targets.Add(options);
        return options;
    }
}
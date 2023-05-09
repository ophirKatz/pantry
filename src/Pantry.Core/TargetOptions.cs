namespace Pantry;

public class TargetOptions<TTarget> : ITargetOptions<TTarget> where TTarget : Target
{
    private readonly string _name;
    private readonly List<string> _runBefore;
    private readonly List<string> _runAfter;
    private readonly List<Action<TTarget>> _configurations;

    public TargetOptions(string name)
    {
        _name = name;
        _runBefore = new List<string>();
        _runAfter = new List<string>();
        _configurations = new List<Action<TTarget>>();
    }

    public IReadOnlyList<string> RunBefore => _runBefore.AsReadOnly();
    public IReadOnlyList<string> RunAfter => _runAfter.AsReadOnly();
    public IReadOnlyList<Action<TTarget>> Configurations => _configurations.AsReadOnly();

    public ITargetOptions<TTarget> Configure(Action<TTarget> action)
    {
        _configurations.Add(action);
        return this;
    }

    public ITargetOrderOptions Before(string name)
    {
        _runBefore.Add(name);
        return this;
    }

    public ITargetOrderOptions After(string name)
    {
        _runAfter.Add(name);
        return this;
    }
}
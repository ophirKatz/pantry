namespace Pantry.Core;

public class TargetOptions<TTarget> : ITargetOptions<TTarget> where TTarget : Target
{
    private readonly List<TargetDescriptor> _runBefore;
    private readonly List<TargetDescriptor> _runAfter;
    private readonly List<Action<TTarget>> _configurations;

    public TargetOptions()
    {
        _runBefore = new List<TargetDescriptor>();
        _runAfter = new List<TargetDescriptor>();
        _configurations = new List<Action<TTarget>>();
    }

    public IReadOnlyList<TargetDescriptor> RunBefore => _runBefore.AsReadOnly();
    public IReadOnlyList<TargetDescriptor> RunAfter => _runAfter.AsReadOnly();
    public IReadOnlyList<Action<TTarget>> Configurations => _configurations.AsReadOnly();

    public ITargetOptions<TTarget> Configure(Action<TTarget> action)
    {
        _configurations.Add(action);
        return this;
    }

    public ITargetOrderOptions Before<TOther>(string name)
    {
        _runBefore.Add(new TargetDescriptor(name, typeof(TOther)));
        return this;
    }

    public ITargetOrderOptions After<TOther>(string name)
    {
        _runAfter.Add(new TargetDescriptor(name, typeof(TOther)));
        return this;
    }
}
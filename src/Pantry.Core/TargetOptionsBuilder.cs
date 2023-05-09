﻿namespace Pantry;

public sealed class TargetOptionsBuilder<TTarget> : ITargetOptionsBuilder<TTarget>, ITargetNodeDefinitionsBuilder where TTarget : Target, new()
{
    private readonly List<string> _runBefore;
    private readonly List<string> _runAfter;
    private readonly List<Action<TTarget>> _configurations;

    public TargetOptionsBuilder(string name)
    {
        _runBefore = new List<string>();
        _runAfter = new List<string>();
        _configurations = new List<Action<TTarget>>()
        {
            target => target.Name = name
        };
    }

    public ITargetOptionsBuilder<TTarget> Configure(Action<TTarget> action)
    {
        _configurations.Add(action);
        return this;
    }

    public ITargetOrderBuilder Before(string name)
    {
        _runBefore.Add(name);
        return this;
    }

    public ITargetOrderBuilder After(string name)
    {
        _runAfter.Add(name);
        return this;
    }

    public TargetNodeDefinitions Build()
    {
        var target = new TTarget();
        foreach (var configuration in _configurations)
        {
            configuration(target);
        }

        return new TargetNodeDefinitions(target, _runBefore.AsReadOnly(), _runAfter.AsReadOnly());
    }
}
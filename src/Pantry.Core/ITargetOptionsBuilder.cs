namespace Pantry;

public interface ITargetOrderBuilder
{
    ITargetOrderBuilder Before(string name);
    ITargetOrderBuilder After(string name);
}

public interface ITargetOptionsBuilder<out TTarget> : ITargetOrderBuilder where TTarget : Target
{
    ITargetOptionsBuilder<TTarget> Configure(Action<TTarget> action);
}
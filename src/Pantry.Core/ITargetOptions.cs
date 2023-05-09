namespace Pantry;

public interface ITargetOptions
{
    
}

public interface ITargetOrderOptions
{
    ITargetOrderOptions Before(string name);
    ITargetOrderOptions After(string name);
}

public interface ITargetOptions<out TTarget> : ITargetOrderOptions, ITargetOptions where TTarget : Target
{
    ITargetOptions<TTarget> Configure(Action<TTarget> action);
}
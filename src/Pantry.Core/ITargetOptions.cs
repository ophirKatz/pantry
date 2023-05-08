namespace Pantry.Core;

public interface ITargetOrderOptions
{
    ITargetOrderOptions Before<TOther>(string name);
    ITargetOrderOptions After<TOther>(string name);
}

public interface ITargetOptions<out TTarget> : ITargetOrderOptions where TTarget : Target
{
    ITargetOptions<TTarget> Configure(Action<TTarget> action);
}
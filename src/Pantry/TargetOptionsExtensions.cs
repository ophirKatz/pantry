namespace Pantry;

public static class TargetOptionsExtensions
{
    public static ITargetOptions<TTarget> WithDescription<TTarget>(this ITargetOptions<TTarget> options, string description)
        where TTarget : Target
    {
        return options.Configure(x => x.Description = description);
    }
}
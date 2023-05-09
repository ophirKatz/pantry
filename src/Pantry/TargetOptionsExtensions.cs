namespace Pantry;

public static class TargetOptionsExtensions
{
    public static ITargetOptionsBuilder<TTarget> WithDescription<TTarget>(this ITargetOptionsBuilder<TTarget> builderBuilder, string description)
        where TTarget : Target
    {
        return builderBuilder.Configure(x => x.Description = description);
    }
}
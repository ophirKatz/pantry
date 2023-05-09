namespace Pantry;

public static class TargetActionsExtensions
{
    public static ITargetOptions<Download> Download(this TargetActions actions, string name)
    {
        return actions.Target<Download>(name);
    }
}
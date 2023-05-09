namespace Pantry;

public static class TargetActionsExtensions
{
    public static ITargetOptionsBuilder<Download> Download(this TargetActions actions, string name)
    {
        return actions.Target<Download>(name);
    }
}
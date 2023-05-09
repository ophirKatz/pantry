namespace Pantry;

internal class TargetBuilder
{
    internal TTarget Build<TTarget>(ITargetNode node) where TTarget : Target, new()
    {
        var target = new TTarget();
        foreach (var configure in node.Configurations)
        {
            configure(target);
        }

        return target;
    }
}
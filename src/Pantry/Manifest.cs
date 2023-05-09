namespace Pantry;

public abstract class Manifest
{
    public virtual bool CanExecute()
    {
        return true;
    }

    public abstract void Execute(TargetActions actions);
}
namespace Pantry;

public abstract class Recipe
{
    public virtual bool CanPrepare()
    {
        return true;
    }

    public abstract void Prepare(Instructions instructions);
}
namespace Pantry.Core;

public abstract class Catalog
{
    public virtual bool CanExecute()
    {
        return true;
    }

    public abstract void Execute(CatalogContext context);
}
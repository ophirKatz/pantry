namespace Pantry;

internal sealed class AggregateRecipe : Recipe
{
    private readonly IEnumerable<Recipe> _recipes;

    public AggregateRecipe(IEnumerable<Recipe> recipes)
    {
        _recipes = recipes;
    }

    public override void Prepare(Instructions instructions)
    {
        foreach (var recipe in _recipes.Where(r => r.CanPrepare()))
        {
            recipe.Prepare(instructions);
        }
    }
}
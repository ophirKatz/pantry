namespace Pantry.Extensions.Chocolatey;

public static class PantryHostBuilderExtensions
{
    public static PantryHostBuilder UseChocolatey(this PantryHostBuilder builder)
    {
        return builder.UseRecipe<ChocolateyRecipe>();
    }
}
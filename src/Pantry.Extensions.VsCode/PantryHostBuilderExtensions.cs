namespace Pantry.Extensions.VsCode;

public static class PantryHostBuilderExtensions
{
    public static PantryHostBuilder UseVsCode(this PantryHostBuilder builder)
    {
        return builder.UseRecipe<VsCodeRecipe>();
    }
}
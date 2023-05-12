namespace Pantry.Extensions.Chocolatey;

internal class ChocolateyRecipe : Recipe
{
    public override void Prepare(Instructions instructions)
    {
        instructions
            .Download("Download Chocolatey", options =>
            {
                options.FromUrl("https://chocolatey.org/install.ps1");
                options.ToFile("~/install-chocolatey.ps1");
            });

        // TODO : Install Chocolatey
    }
}
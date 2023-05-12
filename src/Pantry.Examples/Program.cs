using Pantry;
using Pantry.Extensions.Chocolatey;
using Pantry.Extensions.VsCode;

var pantry = PantryHost.CreateBuilder()
    .UseChocolatey()
    .UseVsCode()
    .UseRecipe<IceDevelopmentRecipe>()
    .Build();

pantry.Make();

/// <summary>
/// Download and install NodeJs
/// Download and install git
/// Download and install python and save at a specific place
/// clone git repo
/// install yarn globally using npm
/// create appsettings.local.json file
/// set env variables
/// download and install vscode
/// install dotnet sdk
/// install dotnet tools
/// </summary>
public class IceDevelopmentRecipe : Recipe
{
    public override void Prepare(Instructions instructions)
    {

        //instructions.PowerShell("Install Chocolatey")
        //    .Script("~/install-chocolatey.ps1")
        //    .Flavor(PowerShellFlavor.PowerShell)
        //    .RequireAdministrator()
        //    .Unless("if (Test-Path \"$($env:ProgramData)/chocolatey/choco.exe\") { exit 1 }")
        //    //.After<RegistryValue>("Set execution policy")
        //    .After("Download Chocolatey");
    }
}
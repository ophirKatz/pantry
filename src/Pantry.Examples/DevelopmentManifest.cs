namespace Pantry.Examples;

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
public class DevelopmentManifest : Manifest
{
    public override void Execute(TargetActions actions)
    {
        actions.Download("Download Chocolatey")
            .FromUrl("https://chocolatey.org/install.ps1")
            .ToFile("~/install-chocolatey.ps1");

        actions.Powershell("Install Chocolatey")
            .Script("~/install-chocolatey.ps1")
            .Flavor(PowerShellFlavor.PowerShell)
            .RequireAdministrator()
            .Unless("if (Test-Path \"$($env:ProgramData)/chocolatey/choco.exe\") { exit 1 }")
            //.After<RegistryValue>("Set execution policy")
            .After("Download Chocolatey");
    }
}
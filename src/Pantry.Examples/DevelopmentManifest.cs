using Pantry.Core;

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
    public override void Execute(ManifestBuilder builder)
    {
        builder.Download("Download NodeJs")
            .WithDescription("Downloading NodeJs from the web")
            .FromUrl("https://nodejs.org/en/download/")
            .ToFile("~");


    }
}
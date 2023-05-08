using Pantry.Core;
using Pantry.Examples;

var pantry = PantryHost.CreateBuilder()
    .UseManifest<DevelopmentManifest>()
    .Build();

pantry.Run();
using Pantry.Core;
using Pantry.Examples;

var pantry = PantryHost.CreateBuilder()
    .AddCatalog<DevelopmentEnvironment>()
    .Build();

pantry.Run();
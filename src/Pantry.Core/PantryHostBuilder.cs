using Microsoft.Extensions.Hosting;

namespace Pantry.Core;

public class PantryHostBuilder
{
    private readonly IHostBuilder _hostBuilder;

    public PantryHostBuilder()
    {
        _hostBuilder = Host.CreateDefaultBuilder();
        _hostBuilder.ConfigureServices(services =>
        {
            return;
        });
    }

    public PantryHostBuilder AddCatalog<TCatalog>() where TCatalog : Catalog
    {
        return this;
    }

    /// <summary>
    /// Configure the output stream
    /// </summary>
    /// <returns></returns>
    public PantryHostBuilder WriteOutputTo()
    {
        return this;
    }

    public PantryHost Build()
    {
        var host = _hostBuilder.Build();
        return new PantryHost(host);
    }
}
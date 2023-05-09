using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Pantry;

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

    public PantryHostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
    {
        _hostBuilder.ConfigureServices(configureServices);
        return this;
    }

    public PantryHostBuilder UseManifest<TCatalog>() where TCatalog : Manifest
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
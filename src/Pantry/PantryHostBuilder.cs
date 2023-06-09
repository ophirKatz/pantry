﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pantry.Contracts.Environment;
using Pantry.Contracts.FileSystem;
using Pantry.Contracts.Logging;
using Pantry.Download;
using Pantry.Execution;
using Pantry.Infrastructure.Environment;
using Pantry.Infrastructure.FileSystem;
using Pantry.Infrastructure.Logging;

namespace Pantry;

public class PantryHostBuilder
{
    private readonly IHostBuilder _hostBuilder;

    public PantryHostBuilder()
    {
        _hostBuilder = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<Instructions>();

                services.AddSingleton<IInstructionFactory, InstructionFactory>();
                services.AddSingleton<IInstructionFactory<Download.Download>, DownloadFactory>();
                // TODO : Register all instruction factories

                services.AddTransient<IInstructionExecutor<Download.Download>, DownloadExecutor>();

                services.AddSingleton<IPantryLogger, PantryLogger>();
                services.AddSingleton<IPantryFileSystem, PantryFileSystem>();
                services.AddSingleton<IPantryEnvironment, PantryEnvironment>();

                services.AddSingleton<AggregateRecipe>();
            });
    }

    public PantryHostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
    {
        _hostBuilder.ConfigureServices(configureServices);
        return this;
    }

    public PantryHostBuilder UseRecipe<TRecipe>() where TRecipe : Recipe
    {
        _hostBuilder.ConfigureServices(services =>
        {
            services.AddTransient(typeof(Recipe), typeof(TRecipe));
        });
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
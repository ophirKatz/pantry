using Microsoft.Extensions.Hosting;

namespace Pantry;

public class PantryHost
{
    public static PantryHostBuilder CreateBuilder() => new();

    private readonly IHost _host;

    internal PantryHost(IHost host)
    {
        _host = host;
    }

    public int Run()
    {
        try
        {
            _host.Run();
            return 0;
        }
        catch (Exception e)
        {
            return -1;
        }
    }
}
namespace Pantry;

public static class DownloadOptionsExtensions
{
    public static ITargetOptions<Download> FromUrl(this ITargetOptions<Download> options, string url)
    {
        return options.Configure(x => x.Url = new Uri(url));
    }

    public static ITargetOptions<Download> ToFile(this ITargetOptions<Download> options, string filename)
    {
        return options.Configure(x => x.Destination = filename);
    }
}
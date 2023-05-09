namespace Pantry;

public static class DownloadOptionsExtensions
{
    public static ITargetOptionsBuilder<Download> FromUrl(this ITargetOptionsBuilder<Download> builderBuilder, string url)
    {
        return builderBuilder.Configure(x => x.Url = new Uri(url));
    }

    public static ITargetOptionsBuilder<Download> ToFile(this ITargetOptionsBuilder<Download> builderBuilder, string filename)
    {
        return builderBuilder.Configure(x => x.Destination = filename);
    }
}
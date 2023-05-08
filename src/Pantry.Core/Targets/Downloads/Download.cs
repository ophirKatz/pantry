namespace Pantry.Core.Targets.Downloads;

public sealed class Download : Target
{
    public Uri? Url { get; set; }
    public Path? Destination { get; set; }

    public Download(string name)
        : base(name)
    {
        if (Uri.TryCreate(name, UriKind.Absolute, out var result))
        {
            Url = result;
        }
    }
}
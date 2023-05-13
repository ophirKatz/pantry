using Spectre.IO;
using Path = Spectre.IO.Path;

namespace Pantry.Download;

public sealed class Download : Instruction
{
    public Download(string name) : base(name)
    {
        if (Uri.TryCreate(name, UriKind.Absolute, out var result))
        {
            Url = result;
        }
    }

    internal Uri? Url { get; set; }
    internal Path? Destination { get; set; }

    public void FromUrl(string url)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out var result)) return;
        Url = result;
    }

    public void ToFile(FilePath path) => Destination = path;
    public void ToDirectory(DirectoryPath path) => Destination = path;
}
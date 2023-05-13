namespace Pantry.Download;

public class DownloadFactory : IInstructionFactory<Download>
{
    public Download Create(string name) => new(name);
}
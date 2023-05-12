using Pantry.Core.Instructions;

namespace Pantry;

public class DownloadFactory : IInstructionFactory<Download>
{
    public Download Create(string name) => new(name);
}
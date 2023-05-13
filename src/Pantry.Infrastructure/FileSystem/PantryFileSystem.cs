using Pantry.Contracts.FileSystem;
using Spectre.IO;

namespace Pantry.Infrastructure.FileSystem;

public sealed class PantryFileSystem : IPantryFileSystem
{
    private readonly IFileSystem _fileSystem;

    public IFileProvider File => _fileSystem.File;
    public IDirectoryProvider Directory => _fileSystem.Directory;

    public PantryFileSystem()
    {
        _fileSystem = new Spectre.IO.FileSystem();
    }
}
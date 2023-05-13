using Spectre.IO;

namespace Pantry.Contracts.Environment;

public interface IPantryEnvironment : IEnvironment
{
    FilePath GetTempFilePath();
}
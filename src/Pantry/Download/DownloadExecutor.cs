using System.Text.RegularExpressions;
using Pantry.Contracts.Environment;
using Pantry.Contracts.FileSystem;
using Pantry.Contracts.Logging;
using Pantry.Execution;
using Spectre.IO;
using ExecutionContext = Pantry.Execution.ExecutionContext;
using Path = Spectre.IO.Path;

namespace Pantry.Download;

public class DownloadExecutor : IInstructionExecutor<Download>
{
    private static readonly Regex ContentDispositionRegex = new("filename=\"(?'filename'.*)\"");

    private readonly IPantryLogger _logger;
    private readonly IPantryFileSystem _fileSystem;
    private readonly IPantryEnvironment _environment;
    private readonly HttpClient _httpClient;

    public DownloadExecutor(IPantryLogger logger,
        IPantryFileSystem fileSystem,
        IPantryEnvironment environment)
    {
        _logger = logger;
        _fileSystem = fileSystem;
        _environment = environment;
        _httpClient = new HttpClient();
    }

    public async Task<ExecutionResult> ExecuteAsync(Download instruction, ExecutionContext context, CancellationToken cancellationToken = default)
    {
        if (instruction.Url is null)
        {
            _logger.Error($"Can't download file {instruction.Name} since no URL has been set");
            return ExecutionResult.Error;
        }

        if (instruction.Destination == null)
        {
            _logger.Error($"Can't download file from {instruction.Url.AbsoluteUri} since destination has not been set");
            return ExecutionResult.Error;
        }

        if (context.DryRun)
        {
            return ExecutionResult.Unknown;
        }

        using var request = new HttpRequestMessage(HttpMethod.Get, instruction.Url);
        using var response = await _httpClient.SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        string? filename = null;
        if (response.Headers.TryGetValues("Content-Disposition", out var fileNames))
        {
            var match = ContentDispositionRegex.Match(fileNames.First());
            if (match.Success && match.Groups.ContainsKey("filename"))
            {
                filename = match.Groups["filename"].Value;
            }
        }

        var path = GetDestinationPath(instruction.Destination, filename);
        if (path == null)
        {
            return ExecutionResult.Error;
        }

        if (_fileSystem.Exist(path))
        {
            _logger.Debug($"File has already been downloaded from {instruction.Url.AbsoluteUri}");
            return ExecutionResult.Unchanged;
        }

        _logger.Debug($"Downloading file from {instruction.Url.AbsoluteUri}");
        await using var inputStream = await response.Content.ReadAsStreamAsync(cancellationToken)
            .ConfigureAwait(false);
        await using var outputStream = _fileSystem.GetFile(path).OpenWrite();
        await inputStream.CopyToAsync(outputStream, cancellationToken).ConfigureAwait(false);

        // TODO
        //if (instruction.Permissions != null)
        //{
        //    path.SetPermissions(instruction.Permissions);
        //}

        return ExecutionResult.Success;
    }

    private FilePath? GetDestinationPath(Path? path, string? filename)
    {
        if (path == null)
        {
            _logger.Error("Unknown destination type");
            return null;
        }

        switch (path)
        {
            case DirectoryPath directory when filename != null:
                return directory
                    .MakeAbsolute(_environment)
                    .CombineWithFilePath(filename);
            case DirectoryPath:
                _logger.Error("Could not resolve filename from download URL");
                return null;
            case FilePath file:
                return file.MakeAbsolute(_environment);
        }

        return null;
    }
}
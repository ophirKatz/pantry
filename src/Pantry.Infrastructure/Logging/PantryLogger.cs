using Pantry.Contracts.Logging;
using Spectre.Console;

namespace Pantry.Infrastructure.Logging;

public class PantryLogger : IPantryLogger
{
    private readonly IAnsiConsole _console;

    public PantryLogger(IAnsiConsole console)
    {
        _console = console ?? throw new ArgumentNullException(nameof(console));
        Verbosity = Verbosity.Normal;
    }

    public Verbosity Verbosity { get; private set; }

    public void SetVerbosity(Verbosity verbosity) => Verbosity = verbosity;

    public void Fatal(string markup) => Log(Verbosity.Quiet, LogLevel.Fatal, markup);
    public void Error(string markup) => Log(Verbosity.Quiet, LogLevel.Error, markup);
    public void Warning(string markup) => Log(Verbosity.Minimal, LogLevel.Warning, markup);
    public void Information(string markup) => Log(Verbosity.Normal, LogLevel.Information, markup);
    public void Verbose(string markup) => Log(Verbosity.Verbose, LogLevel.Verbose, markup);
    public void Debug(string markup) => Log(Verbosity.Diagnostic, LogLevel.Debug, markup);
    public void Fatal(string title, string markup) => Log(Verbosity.Quiet, LogLevel.Fatal, title, markup);
    public void Error(string title, string markup) => Log(Verbosity.Quiet, LogLevel.Error, title, markup);
    public void Warning(string title, string markup) => Log(Verbosity.Minimal, LogLevel.Warning, title, markup);
    public void Information(string title, string markup) => Log(Verbosity.Normal, LogLevel.Information, title, markup);
    public void Verbose(string title, string markup) => Log(Verbosity.Verbose, LogLevel.Verbose, title, markup);
    public void Debug(string title, string markup) => Log(Verbosity.Diagnostic, LogLevel.Debug, title, markup);

    private void Log(Verbosity verbosity, LogLevel level, string text)
    {
        if (verbosity > Verbosity)
        {
            return;
        }

        switch (level)
        {
            case LogLevel.Fatal:
            case LogLevel.Error:
                _console.MarkupLine($"[red]{text}[/]");
                break;
            case LogLevel.Warning:
                _console.MarkupLine($"[yellow]{text}[/]");
                break;
            case LogLevel.Information:
                _console.MarkupLine($"{text}");
                break;
            case LogLevel.Verbose:
            case LogLevel.Debug:
                _console.MarkupLine($"[grey]{text}[/]");
                break;
        }
    }

    private void Log(Verbosity verbosity, LogLevel level, string title, string text)
    {
        if (verbosity > Verbosity)
        {
            return;
        }

        switch (level)
        {
            case LogLevel.Fatal:
            case LogLevel.Error:
                WriteGrid($"[red]{title}[/]", $"[red]{text}[/]");
                break;
            case LogLevel.Warning:
                WriteGrid($"[yellow]{title}[/]", $"[red]{text}[/]");
                break;
            case LogLevel.Information:
                WriteGrid(title, text);
                break;
            case LogLevel.Verbose:
            case LogLevel.Debug:
                WriteGrid($"[grey]{title}[/]", $"[grey]{text}[/]");
                break;
        }
    }

    private void WriteGrid(string title, string text)
    {
        _console.Write(new Grid()
            .AddColumn(new GridColumn().PadRight(1))
            .AddColumn()
            .AddRow(title, text));
    }
}
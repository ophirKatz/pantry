namespace Pantry.Contracts.Logging;

public interface IPantryLogger
{
    Verbosity Verbosity { get; }

    void SetVerbosity(Verbosity verbosity);

    void Fatal(string markup);
    void Error(string markup);
    void Warning(string markup);
    void Information(string markup);
    void Verbose(string markup);
    void Debug(string markup);
    void Fatal(string title, string markup);
    void Error(string title, string markup);
    void Warning(string title, string markup);
    void Information(string title, string markup);
    void Verbose(string title, string markup);
    void Debug(string title, string markup);
}
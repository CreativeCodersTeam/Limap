namespace CreativeCoders.LinuxManagementPlatform.Core.CommandExecution;

public class CommandResultWithOutput
{
    public int ExitCode { get; init; }

    public IEnumerable<string> Output { get; init; } = Array.Empty<string>();
}
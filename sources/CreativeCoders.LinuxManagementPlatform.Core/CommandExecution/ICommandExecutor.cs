namespace CreativeCoders.LinuxManagementPlatform.Core.CommandExecution;

public interface ICommandExecutor
{
    Task<int> ExecuteAsync(string command, params string[] arguments);

    Task<CommandResultWithOutput> ExecuteWithOutputAsync(string command, params string[] arguments);
}
using System.Diagnostics;
using CreativeCoders.Core.Collections;

namespace CreativeCoders.LinuxManagementPlatform.Core.CommandExecution;

public class CommandExecutor : ICommandExecutor
{
    public async Task<int> ExecuteAsync(string command, params string[] arguments)
    {
        var process = RunProcess(command, arguments);
        
        process.Start();

        await process.WaitForExitAsync();

        return process.ExitCode;
    }

    public Task<CommandResultWithOutput> ExecuteWithOutputAsync(string command, params string[] arguments)
    {
        throw new NotImplementedException();
    }

    private static Process RunProcess(string command, IEnumerable<string> arguments, Action<Process>? configure = null)
    {
        var process = new Process();

        process.StartInfo.FileName = command;

        arguments.ForEach(x => process.StartInfo.ArgumentList.Add(x));

        process.StartInfo.UseShellExecute = false;

        configure?.Invoke(process);

        return process;
    }
}
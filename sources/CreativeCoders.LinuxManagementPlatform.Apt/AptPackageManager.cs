using CreativeCoders.LinuxManagementPlatform.Core.CommandExecution;

namespace CreativeCoders.LinuxManagementPlatform.Apt;

internal class AptPackageManager : IAptPackageManager
{
    private readonly ICommandExecutor _commandExecutor;

    public AptPackageManager(ICommandExecutor commandExecutor)
    {
        _commandExecutor = commandExecutor;
    }

    public async Task<bool> Install(IEnumerable<string> packages)
    {
        var arguments = new List<string>
        {
            "apt-get",
            "install",
            "-y"
        };

        arguments.AddRange(packages);

        return await _commandExecutor.ExecuteAsync("sudo", arguments.ToArray()) == 0;
    }

    public Task<bool> AddRepository(AptRepositoryInfo repositoryInfo)
    {
        throw new NotImplementedException();
    }
}

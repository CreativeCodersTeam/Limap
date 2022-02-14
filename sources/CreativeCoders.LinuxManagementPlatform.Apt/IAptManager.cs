using CreativeCoders.LinuxManagementPlatform.Core.CommandExecution;

namespace CreativeCoders.LinuxManagementPlatform.Apt;

public interface IAptManager
{
    Task<bool> Install(IEnumerable<string> packages);

    Task<bool> AddRepository(AptRepositoryInfo repositoryInfo);
}

internal class AptManager : IAptManager
{
    private readonly ICommandExecutor _commandExecutor;

    public AptManager(ICommandExecutor commandExecutor)
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

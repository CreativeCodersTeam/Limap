namespace CreativeCoders.LinuxManagementPlatform.Apt;

public interface IAptPackageManager
{
    Task<bool> Install(IEnumerable<string> packages);

    Task<bool> AddRepository(AptRepositoryInfo repositoryInfo);
}
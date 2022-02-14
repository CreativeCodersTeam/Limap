namespace CreativeCoders.LinuxManagementPlatform.Core;

public interface ILimapSource
{
    Task<IEnumerable<LimapPackageSource>> GetPackageSourcesAsync();
        
}

public class LimapPackageSource
{
    public string Url { get; set; }

    public string Name { get; set; }

    //public string S { get; set; }
}
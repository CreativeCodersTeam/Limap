using CreativeCoders.Core.IO;

namespace CreativeCoders.LinuxManagementPlatform.Core.SystemInfos;

public class LinuxSystemInfo
{
    public LinuxSystemInfo()
    {
        InitSystemInfos();
    }

    private void InitSystemInfos()
    {
        var osRelease = FileSys.File.ReadAllLines("/etc/os-release");

        if (osRelease == null)
        {
            return;
        }

        var nameLine = GetLine(osRelease, "NAME");
        var versionLine = GetLine(osRelease, "VERSION_ID");

        Distro = GetBaseDistro(ReadLineValue(nameLine));
        Version = ReadLineValue(versionLine).Trim('"');
    }

    private static string GetLine(string[] osRelease, string valueName)
    {
        return osRelease.FirstOrDefault(x => x.StartsWith(valueName + "=", StringComparison.CurrentCultureIgnoreCase))
               ?? string.Empty;
    }

    private static BaseDistro GetBaseDistro(string name)
    {
        if (name.Contains("buntu", StringComparison.CurrentCultureIgnoreCase))
        {
            return BaseDistro.Ubuntu;
        }

        return name.Contains("bian", StringComparison.CurrentCultureIgnoreCase)
            ? BaseDistro.Debian
            : BaseDistro.Unknown;
    }

    private string ReadLineValue(string line)
    {
        var index = line.IndexOf("=", StringComparison.OrdinalIgnoreCase);

        return index != -1
            ? line[++index..]
            : string.Empty;
    }

    public BaseDistro Distro { get; private set; }

    public string Version { get; private set; } = string.Empty;
}
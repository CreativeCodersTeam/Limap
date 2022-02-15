
using CreativeCoders.LinuxManagementPlatform.Core.SystemInfos;

var systemInfo = new LinuxSystemInfo();
Console.WriteLine(systemInfo.Distro);
Console.WriteLine(systemInfo.Version);

Console.WriteLine("Hello, World!");
Console.ReadKey();

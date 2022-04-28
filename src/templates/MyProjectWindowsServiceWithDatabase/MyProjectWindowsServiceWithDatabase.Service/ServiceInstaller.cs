using System.ComponentModel;
using Simplify.WindowsServices;

namespace MyProjectWindowsServiceWithDatabase.Service;

[RunInstaller(true)]
public class ServiceInstaller : ServiceInstallerBase
{
}
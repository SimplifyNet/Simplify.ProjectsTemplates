using Microsoft.Extensions.Configuration;
using Simplify.DI;

namespace MyProject.WindowsService.Setup;

public static class IocRegistrations
{
	public static IConfiguration Configuration { get; private set; }

	public static IDIContainerProvider RegisterAll(this IDIContainerProvider provider)
	{
		provider.RegisterConfiguration()
			.Register<Worker>();

		return provider;
	}

	private static IDIRegistrator RegisterConfiguration(this IDIRegistrator registrator)
	{
		Configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", false)
			.Build();

		return registrator.Register(p => Configuration, LifetimeType.Singleton);
	}
}
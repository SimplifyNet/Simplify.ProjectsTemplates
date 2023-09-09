using Microsoft.Extensions.Configuration;
using MyProjectSchedulerWithDatabase.Database.Setup;
using Simplify.DI;

namespace MyProjectSchedulerWithDatabase.Service.Setup;

public static class IocRegistrations
{
	public static IConfiguration Configuration { get; private set; }

	public static IDIContainerProvider RegisterAll(this IDIContainerProvider provider)
	{
		provider.RegisterConfiguration()
			.RegisterMyProjectSchedulerWithDatabase()
			.Register<Worker>();

		return provider;
	}

	private static IDIRegistrator RegisterConfiguration(this IDIRegistrator registrator)
	{
		Configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", false)
			.Build();

		registrator.Register(p => Configuration, LifetimeType.Singleton);

		return registrator;
	}
}
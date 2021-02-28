using Microsoft.Extensions.Configuration;
using MyProjectWindowsServiceWithDatabase.Database.Setup;
using Simplify.DI;

namespace MyProjectWindowsServiceWithDatabase.Service.Setup
{
	public static class IocRegistrations
	{
		public static IConfiguration Configuration { get; private set; }

		public static IDIContainerProvider RegisterAll(this IDIContainerProvider provider)
		{
			provider.RegisterConfiguration()
				.RegisterMyProjectWindowsServiceWithDatabase()
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
}
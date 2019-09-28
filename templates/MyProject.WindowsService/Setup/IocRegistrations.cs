using Microsoft.Extensions.Configuration;
using Simplify.DI;

namespace MyProject.WindowsService.Setup
{
	public class IocRegistrations
	{
		public static IConfiguration Configuration { get; private set; }

		public static void Register()
		{
			RegisterConfiguration();

			DIContainer.Current.Register<Worker>();
		}

		private static void RegisterConfiguration()
		{
			Configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", false)
				.Build();

			DIContainer.Current.Register(p => Configuration, LifetimeType.Singleton);
		}
	}
}
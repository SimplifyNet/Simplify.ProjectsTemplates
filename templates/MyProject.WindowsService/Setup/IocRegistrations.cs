﻿using Microsoft.Extensions.Configuration;
using Simplify.DI;

namespace MyProject.WindowsService.Setup
{
	public static class IocRegistrations
	{
		public static IConfiguration Configuration { get; private set; }

		public static IDIContainerProvider Register()
		{
			DIContainer.Current.RegisterConfiguration()
				.Register<Worker>();

			return DIContainer.Current;
		}

		private static IDIRegistrator RegisterConfiguration(this IDIRegistrator registrator)
		{
			Configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", false)
				.Build();

			return registrator.Register(p => Configuration, LifetimeType.Singleton);
		}
	}
}
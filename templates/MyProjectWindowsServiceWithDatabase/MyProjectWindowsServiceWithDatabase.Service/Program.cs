using MyProjectWindowsServiceWithDatabase.Service.Infrastructure;
using MyProjectWindowsServiceWithDatabase.Service.Setup;
using Simplify.DI;
using Simplify.DI.Provider.SimpleInjector;
using Simplify.WindowsServices;

namespace MyProjectWindowsServiceWithDatabase.Service
{
	internal class Program
	{
		private static void Main(string[] args)
		{
#if DEBUG
			// Run debugger
			System.Diagnostics.Debugger.Launch();
#endif

			InitializeContainer();

			using var handler = new SingleTaskServiceHandler<Worker>(IocRegistrations.Configuration)
				.SubscribeLog();

			if (!handler.Start(args))
				RunAsAConsoleApplication();
		}

		private static void RunAsAConsoleApplication()
		{
			using var scope = DIContainer.Current.BeginLifetimeScope();
			scope.Resolver.Resolve<Worker>().Run();
		}

		private static void InitializeContainer() => (DIContainer.Current = new SimpleInjectorDIProvider()).RegisterAll().Verify();
	}
}
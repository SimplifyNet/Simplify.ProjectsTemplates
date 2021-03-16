using MyProject.WindowsService.Infrastructure;
using MyProject.WindowsService.Setup;
using Simplify.DI;
using Simplify.WindowsServices;

namespace MyProject.WindowsService
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			//-:cnd:noEmit

#if DEBUG
			// Run debugger
			System.Diagnostics.Debugger.Launch();
#endif
			//+:cnd:noEmit

			// IOC container setup
			IocRegistrations.Register().Verify();

			using var handler = new SingleTaskServiceHandler<Worker>(IocRegistrations.Configuration)
				.SubscribeLog();

			if (!handler.Start(args))
				// One-time launch of user code without the windows-service hosting
				RunAsAConsoleApplication();
		}

		private static void RunAsAConsoleApplication()
		{
			using var scope = DIContainer.Current.BeginLifetimeScope();
			scope.Resolver.Resolve<Worker>().Run();
		}
	}
}
using MyProject.Scheduler.Infrastructure;
using MyProject.Scheduler.Setup;
using Simplify.DI;
using Simplify.Scheduler;

namespace MyProject.Scheduler
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

			using var scheduler = new SingleTaskScheduler<Worker>(IocRegistrations.Configuration)
				.SubscribeLog();

			if (scheduler.Start(args))
				return;

			if (!scheduler.Start(args))
				// Launch without the scheduler for testing
				RunAsAConsoleApplication();
		}

		private static void RunAsAConsoleApplication()
		{
			using var scope = DIContainer.Current.BeginLifetimeScope();
			scope.Resolver.Resolve<Worker>().Run();
		}
	}
}
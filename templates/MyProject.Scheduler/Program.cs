using System.Diagnostics;
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

			InitializeContainer();

			using var scheduler = new SingleTaskScheduler<Worker>(IocRegistrations.Configuration);

			scheduler.OnException += OnException;

			if (scheduler.Start(args))
				return;

			// Launch without the scheduler for testing

			using var scope = DIContainer.Current.BeginLifetimeScope();
			scope.Resolver.Resolve<Worker>().Run();
		}

		private static void OnException(SchedulerExceptionArgs args)
		{
			Trace.WriteLine(args.Exception.Message);
		}

		private static void InitializeContainer()
		{
			IocRegistrations.Register();

			DIContainer.Current.Verify();
		}
	}
}
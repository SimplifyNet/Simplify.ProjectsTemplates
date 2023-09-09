using MyProject.Scheduler.Infrastructure;
using MyProjectWindowsServiceWithDatabase.Service;
using MyProjectWindowsServiceWithDatabase.Service.Setup;
using Simplify.DI;
using Simplify.Scheduler;

// IOC container setup
DIContainer.Current
	.RegisterAll()
	.Verify();

using var scheduler = new SingleTaskScheduler<Worker>(IocRegistrations.Configuration)
	.SubscribeLog();

if (!scheduler.Start(args))
{
	// One-time launch of user code without the scheduler

	using var scope = DIContainer.Current.BeginLifetimeScope();

	scope.Resolver.Resolve<Worker>()
		.Run()
		.ConfigureAwait(false)
		.GetAwaiter()
		.GetResult();
}

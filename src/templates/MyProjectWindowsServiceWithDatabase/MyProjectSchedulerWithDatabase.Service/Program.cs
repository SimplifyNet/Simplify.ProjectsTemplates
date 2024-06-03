using MyProjectSchedulerWithDatabase.Service;
using MyProjectSchedulerWithDatabase.Service.Infrastructure;
using MyProjectSchedulerWithDatabase.Service.Setup;
using Simplify.DI;
using Simplify.Scheduler;

// IOC container setup
DIContainer.Current
	.RegisterAll()
	.Verify();

using var scheduler = new SingleTaskScheduler<Worker>(IocRegistrations.Configuration)
	.SubscribeLog();

if (!await scheduler.StartAsync(args))
{
	// One-time launch of user code without the scheduler

	using var scope = DIContainer.Current.BeginLifetimeScope();

	await scope.Resolver.Resolve<Worker>()
		.Run();
}
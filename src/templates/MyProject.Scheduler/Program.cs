using MyProject.Scheduler;
using MyProject.Scheduler.Infrastructure;
using MyProject.Scheduler.Setup;
using Simplify.DI;
using Simplify.Scheduler;

// IOC container setup
DIContainer.Current
	.RegisterAll()
	.Verify();

using var scheduler = new SingleTaskScheduler<WorkerAsync>(IocRegistrations.Configuration)
	.SubscribeLog();

if (await scheduler.StartAsync(args))
	return;


// One-time launch of user code without the scheduler

using var scope = DIContainer.Current.BeginLifetimeScope();
await scope.Resolver.Resolve<WorkerAsync>().Run();


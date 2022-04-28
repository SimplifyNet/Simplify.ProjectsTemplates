using MyProjectWindowsServiceWithDatabase.Service;
using MyProjectWindowsServiceWithDatabase.Service.Infrastructure;
using MyProjectWindowsServiceWithDatabase.Service.Setup;
using Simplify.DI;
using Simplify.DI.Provider.SimpleInjector;
using Simplify.WindowsServices;

#if DEBUG
			// Run debugger
			System.Diagnostics.Debugger.Launch();
#endif

(DIContainer.Current = new SimpleInjectorDIProvider())
	.RegisterAll()
	.Verify();

using var handler = new SingleTaskServiceHandler<Worker>(IocRegistrations.Configuration)
	.SubscribeLog();

if (!handler.Start(args))
{
	using var scope = DIContainer.Current.BeginLifetimeScope();
	scope.Resolver.Resolve<Worker>().Run();
}

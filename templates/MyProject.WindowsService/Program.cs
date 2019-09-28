using System.Diagnostics;
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

			InitializeContainer();

			using (var handler = new SingleTaskServiceHandler<Worker>(IocRegistrations.Configuration))
			{
				handler.OnException += OnException;

				if (handler.Start(args))
					return;
			}

			// On  time launch as a console application for testing
			using (var scope = DIContainer.Current.BeginLifetimeScope())
				scope.Resolver.Resolve<Worker>().Run();
		}

		private static void OnException(ServiceExceptionArgs args)
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
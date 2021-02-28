using Simplify.DI;
using Simplify.WindowsServices;

namespace MyProjectWindowsServiceWithDatabase.Service.Infrastructure
{
	public static class WindowsServiceHandlerObserver
	{
		public static MultitaskServiceHandler SubscribeLog(this MultitaskServiceHandler handler)
		{
			handler.OnException += OnException;

			return handler;
		}

		private static void OnException(ServiceExceptionArgs args)
		{
			using var scope = DIContainer.Current.BeginLifetimeScope();

			// Exception processing
		}
	}
}
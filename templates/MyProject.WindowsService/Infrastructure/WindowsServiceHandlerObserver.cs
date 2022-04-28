using System.Diagnostics;
using Simplify.WindowsServices;

namespace MyProject.WindowsService.Infrastructure;

public static class WindowsServiceHandlerObserver
{
	public static MultitaskServiceHandler SubscribeLog(this MultitaskServiceHandler handler)
	{
		handler.OnException += OnException;

		return handler;
	}

	private static void OnException(ServiceExceptionArgs args) => Trace.WriteLine(args.Exception.Message);
}
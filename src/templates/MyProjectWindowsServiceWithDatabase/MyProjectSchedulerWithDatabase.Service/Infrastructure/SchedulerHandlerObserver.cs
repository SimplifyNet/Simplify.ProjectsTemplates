using System.Diagnostics;
using Simplify.Scheduler;

namespace MyProjectSchedulerWithDatabase.Service.Infrastructure;

public static class SchedulerHandlerObserver
{
	public static MultitaskScheduler SubscribeLog(this MultitaskScheduler handler)
	{
		handler.OnException += OnException;

		return handler;
	}

	private static void OnException(SchedulerExceptionArgs args) => Trace.TraceInformation(args.Exception.Message);
}
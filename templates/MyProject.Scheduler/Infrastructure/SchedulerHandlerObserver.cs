using System.Diagnostics;
using Simplify.Scheduler;

namespace MyProject.Scheduler.Infrastructure
{
	public static class SchedulerHandlerObserver
	{
		public static MultitaskScheduler SubscribeLog(this MultitaskScheduler handler)
		{
			handler.OnException += OnException;

			return handler;
		}

		private static void OnException(SchedulerExceptionArgs args)
		{
			Trace.WriteLine(args.Exception.Message);
		}
	}
}
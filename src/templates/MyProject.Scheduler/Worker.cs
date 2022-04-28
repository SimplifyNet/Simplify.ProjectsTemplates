using System.Diagnostics;

namespace MyProject.Scheduler;

internal class Worker
{
	public void Run() => Trace.WriteLine("Hello world!");
}
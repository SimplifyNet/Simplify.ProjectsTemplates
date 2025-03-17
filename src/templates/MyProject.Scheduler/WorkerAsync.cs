using System;
using System.Threading.Tasks;

namespace MyProject.Scheduler;

// Example of a class that will be executed by Simplify.Scheduler
internal class WorkerAsync
{
	public Task Run()
	{
		Console.WriteLine("Hello world!");

		return Task.CompletedTask;
	}
}
using System.Diagnostics;

namespace MyProject.WindowsService
{
	internal class Worker
	{
		public void Run()
		{
			Trace.WriteLine("Hello world!");
		}
	}
}
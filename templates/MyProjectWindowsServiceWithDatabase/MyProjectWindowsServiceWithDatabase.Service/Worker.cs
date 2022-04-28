using MyProjectWindowsServiceWithDatabase.MyEntities;

namespace MyProjectWindowsServiceWithDatabase.Service;

internal class Worker
{
	private readonly IMyEntityServiceService _service;

	public Worker(IMyEntityServiceService service) => _service = service;

	public void Run()
	{
		var items = _service.GetAllAsync().Result;

		// TODO
	}
}
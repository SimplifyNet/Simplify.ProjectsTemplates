using System.Threading.Tasks;
using MyProjectSchedulerWithDatabase.MyEntities;

namespace MyProjectSchedulerWithDatabase.Service;

internal class Worker
{
	private readonly IMyEntityServiceService _service;

	public Worker(IMyEntityServiceService service) => _service = service;

	public async Task Run()
	{
		var items = await _service.GetAllAsync();

		// TODO
	}
}
using System.Threading.Tasks;
using MyProjectSchedulerWithDatabase.MyEntities;

namespace MyProjectSchedulerWithDatabase.Service;

internal class Worker(IMyEntityServiceService service)
{
	public async Task Run()
	{
		var items = await service.GetAllAsync();

		// TODO
	}
}
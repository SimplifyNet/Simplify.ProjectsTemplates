using System.Collections.Generic;
using System.Threading.Tasks;
using Simplify.Repository;

namespace MyProjectSchedulerWithDatabase.MyEntities;

public class MyEntityService(IGenericRepository<IMyEntity> repository) : IMyEntityServiceService
{
	public Task<IList<IMyEntity>> GetAllAsync() => repository.GetMultipleAsync();
}
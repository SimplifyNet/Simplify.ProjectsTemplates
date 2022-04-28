using System.Collections.Generic;
using System.Threading.Tasks;
using Simplify.Repository;

namespace MyProjectWindowsServiceWithDatabase.MyEntities;

public class MyEntityService : IMyEntityServiceService
{
	private readonly IGenericRepository<IMyEntity> _repository;

	public MyEntityService(IGenericRepository<IMyEntity> repository) => _repository = repository;

	public Task<IList<IMyEntity>> GetAllAsync() => _repository.GetMultipleByQueryAsync();
}
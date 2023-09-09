using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProjectSchedulerWithDatabase.MyEntities;

public interface IMyEntityServiceService
{
	Task<IList<IMyEntity>> GetAllAsync();
}
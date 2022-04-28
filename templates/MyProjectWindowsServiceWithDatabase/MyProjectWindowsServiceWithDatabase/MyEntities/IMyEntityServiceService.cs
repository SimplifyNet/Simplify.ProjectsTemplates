using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProjectWindowsServiceWithDatabase.MyEntities;

public interface IMyEntityServiceService
{
	Task<IList<IMyEntity>> GetAllAsync();
}
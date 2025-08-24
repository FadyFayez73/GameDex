using Domain.Entities;
using Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPlatformRepository : IBaseRepository<Platform>
    {
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
        Task<Platform?> GetPlatformByIdAsync(Guid platformId);
        Task<Platform?> GetPlatformByNameAsync(string name);
        Task<IEnumerable<Platform>> GetPlatformsByIdsAsync(List<Guid> ids);
        Task<IEnumerable<Platform>> GetPlatformsByNamesAsync(List<string> names);

    }
}

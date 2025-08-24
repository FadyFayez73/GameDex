using Domain.Entities;
using Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPlatformServices : IBaseServices<Platform>
    {
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
        Task<Platform?> GetPlatformByIdAsync(Guid id);
        Task<Platform?> GetPlatformByNameAsync(string name);
    }
}

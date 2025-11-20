using Domain.Repositories.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IDLCRepository : IBaseRepository<DLC>
    {
        Task<IEnumerable<DLC>> GetAllDLCsAsync();
        Task<DLC?> GetDLCByIdAsync(Guid id);
        Task<DLC?> GetDLCByNameAsync(string name);
        Task<IEnumerable<DLC>> GetDLCsByGameIdAsync(Guid gameId);
    }
} 
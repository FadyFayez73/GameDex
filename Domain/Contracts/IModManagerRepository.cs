using Domain.Repositories.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IModManagerRepository : IBaseRepository<ModManager>
    {
        Task<IEnumerable<ModManager>> GetAllModManagersAsync();
        Task<ModManager?> GetModManagerByIdAsync(Guid id);
        Task<IEnumerable<ModManager>> GetModManagersByGameIdAsync(Guid gameId);
    }
} 
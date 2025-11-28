using Domain.Entities;
using Application.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IModManagerApplication : IBaseApplication<ModManager>
    {
        Task<IEnumerable<ModManager>> GetAllModManagersAsync();
        Task<ModManager?> GetModManagerByIdAsync(Guid id);
        Task<IEnumerable<ModManager>> GetModManagersByGameIdAsync(Guid gameId);
    }
}

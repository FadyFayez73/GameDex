using Domain.Entities;
using Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IModManagerServices : IBaseServices<ModManager>
    {
        Task<IEnumerable<ModManager>> GetAllModManagersAsync();
        Task<ModManager?> GetModManagerByIdAsync(Guid id);
        Task<IEnumerable<ModManager>> GetModManagersByGameIdAsync(Guid gameId);
    }
}

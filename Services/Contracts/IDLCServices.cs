using Domain.Entities;
using Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDLCServices : IBaseServices<DLC>
    {
        Task<IEnumerable<DLC>> GetAllDLCsAsync();
        Task<DLC?> GetDLCByIdAsync(Guid id);
        Task<DLC?> GetDLCByNameAsync(string name);
        Task<IEnumerable<DLC>> GetDLCsByGameIdAsync(Guid gameId);
    }
}

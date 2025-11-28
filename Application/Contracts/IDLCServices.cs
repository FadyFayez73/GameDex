using Domain.Entities;
using Application.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IDLCApplication : IBaseApplication<DLC>
    {
        Task<IEnumerable<DLC>> GetAllDLCsAsync();
        Task<DLC?> GetDLCByIdAsync(Guid id);
        Task<DLC?> GetDLCByNameAsync(string name);
        Task<IEnumerable<DLC>> GetDLCsByGameIdAsync(Guid gameId);
    }
}

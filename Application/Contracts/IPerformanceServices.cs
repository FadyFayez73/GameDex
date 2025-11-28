using Domain.Entities;
using Application.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IPerformanceApplication : IBaseApplication<Performance>
    {
        Task<IEnumerable<Performance>> GetAllPerformancesAsync();
        Task<Performance?> GetPerformanceByIdAsync(Guid id);
        Task<IEnumerable<Performance>> GetPerformancesByGameIdAsync(Guid gameId);
        Task<IEnumerable<Performance>> GetPerformancesByGraphicsQualityAsync(string graphicsQuality);
    }
}

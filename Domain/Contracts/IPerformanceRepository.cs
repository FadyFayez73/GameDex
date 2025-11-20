using Domain.Repositories.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPerformanceRepository : IBaseRepository<Performance>
    {
        Task<IEnumerable<Performance>> GetAllPerformancesAsync();
        Task<Performance?> GetPerformanceByIdAsync(Guid id);
        Task<IEnumerable<Performance>> GetPerformancesByGameIdAsync(Guid gameId);
        Task<IEnumerable<Performance>> GetPerformancesByGraphicsQualityAsync(string graphicsQuality);
    }
} 
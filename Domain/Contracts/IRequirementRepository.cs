using Domain.Repositories.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRequirementRepository : IBaseRepository<Requirement>
    {
        Task<IEnumerable<Requirement>> GetAllRequirementsAsync();
        Task<Requirement?> GetRequirementByIdAsync(Guid id);
        Task<IEnumerable<Requirement>> GetRequirementsByGameIdAsync(Guid gameId);
    }
} 
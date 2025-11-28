using Domain.Entities;
using Application.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IRequirementApplication : IBaseApplication<Requirement>
    {
        Task<IEnumerable<Requirement>> GetAllRequirementsAsync();
        Task<Requirement?> GetRequirementByIdAsync(Guid id);
        Task<IEnumerable<Requirement>> GetRequirementsByGameIdAsync(Guid gameId);
    }
}

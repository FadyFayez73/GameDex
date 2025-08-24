using Domain.Entities;
using Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRequirementServices : IBaseServices<Requirement>
    {
        Task<IEnumerable<Requirement>> GetAllRequirementsAsync();
        Task<Requirement?> GetRequirementByIdAsync(Guid id);
        Task<IEnumerable<Requirement>> GetRequirementsByGameIdAsync(Guid gameId);
    }
}

using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Application
{
    public class RequIrementServices : IRequirementServices
    {
        private readonly IRequirementRepository _requirementRepository;

        public RequIrementServices(IRequirementRepository requirementRepository)
        {
            _requirementRepository = requirementRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Requirement entity)
        {
            entity.RequirementID = Guid.NewGuid();

            var result = await _requirementRepository.AddAsync(entity);

            return (result, entity.RequirementID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var requirement = await _requirementRepository.GetRequirementByIdAsync(id);
            if (requirement == null) return false;

            return await _requirementRepository.DeleteAsync(requirement);
        }

        public async Task<bool> UpdateAsync(Requirement entity)
        {
            var result = await _requirementRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Requirement>> GetAllRequirementsAsync()
        {
            var requirements = await _requirementRepository.GetAllRequirementsAsync();
            return requirements;
        }

        public async Task<Requirement?> GetRequirementByIdAsync(Guid id)
        {
            var requirement = await _requirementRepository.GetRequirementByIdAsync(id);
            return requirement;
        }

        public async Task<IEnumerable<Requirement>> GetRequirementsByGameIdAsync(Guid gameId)
        {
            var requirements = await _requirementRepository.GetRequirementsByGameIdAsync(gameId);
            return requirements;
        }
    }
}

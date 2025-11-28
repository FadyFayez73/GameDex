using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Application
{
    public class ModManagerServices : IModManagerServices
    {
        private readonly IModManagerRepository _modManagerRepository;

        public ModManagerServices(IModManagerRepository modManagerRepository)
        {
            _modManagerRepository = modManagerRepository;
        }

        public async Task<(bool, Guid)> AddAsync(ModManager entity)
        {
            entity.ModManagerID = Guid.NewGuid();

            var result = await _modManagerRepository.AddAsync(entity);

            return (result, entity.ModManagerID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var modManager = await _modManagerRepository.GetModManagerByIdAsync(id);
            if (modManager == null) return false;

            return await _modManagerRepository.DeleteAsync(modManager);
        }

        public async Task<bool> UpdateAsync(ModManager entity)
        {
            var result = await _modManagerRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<ModManager>> GetAllModManagersAsync()
        {
            var modManagers = await _modManagerRepository.GetAllModManagersAsync();
            return modManagers;
        }

        public async Task<ModManager?> GetModManagerByIdAsync(Guid id)
        {
            var modManager = await _modManagerRepository.GetModManagerByIdAsync(id);
            return modManager;
        }

        public async Task<IEnumerable<ModManager>> GetModManagersByGameIdAsync(Guid gameId)
        {
            var modManagers = await _modManagerRepository.GetModManagersByGameIdAsync(gameId);
            return modManagers;
        }
    }
}

using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Application
{
    public class DLCServices : IDLCServices
    {
        private readonly IDLCRepository _dlcRepository;

        public DLCServices(IDLCRepository dlcRepository)
        {
            _dlcRepository = dlcRepository;
        }

        public async Task<(bool, Guid)> AddAsync(DLC entity)
        {
            var dlc = await _dlcRepository.GetDLCByNameAsync(entity.Name);
            if (dlc != null) return (false, Guid.Empty);

            entity.DLCID = Guid.NewGuid();

            var result = await _dlcRepository.AddAsync(entity);

            return (result, entity.DLCID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var dlc = await _dlcRepository.GetDLCByIdAsync(id);
            if (dlc == null) return false;

            return await _dlcRepository.DeleteAsync(dlc);
        }

        public async Task<bool> UpdateAsync(DLC entity)
        {
            var result = await _dlcRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<DLC>> GetAllDLCsAsync()
        {
            var dlcs = await _dlcRepository.GetAllDLCsAsync();
            return dlcs;
        }

        public async Task<DLC?> GetDLCByIdAsync(Guid id)
        {
            var dlc = await _dlcRepository.GetDLCByIdAsync(id);
            return dlc;
        }

        public async Task<DLC?> GetDLCByNameAsync(string name)
        {
            var dlc = await _dlcRepository.GetDLCByNameAsync(name);
            return dlc;
        }

        public async Task<IEnumerable<DLC>> GetDLCsByGameIdAsync(Guid gameId)
        {
            var dlcs = await _dlcRepository.GetDLCsByGameIdAsync(gameId);
            return dlcs;
        }
    }
}

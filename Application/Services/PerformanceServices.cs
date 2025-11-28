using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Application
{
    public class PerformanceServices : IPerformanceServices
    {
        private readonly IPerformanceRepository _performanceRepository;

        public PerformanceServices(IPerformanceRepository performanceRepository)
        {
            _performanceRepository = performanceRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Performance entity)
        {
            entity.PerformanceID = Guid.NewGuid();

            var result = await _performanceRepository.AddAsync(entity);

            return (result, entity.PerformanceID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var performance = await _performanceRepository.GetPerformanceByIdAsync(id);
            if (performance == null) return false;

            return await _performanceRepository.DeleteAsync(performance);
        }

        public async Task<bool> UpdateAsync(Performance entity)
        {
            var result = await _performanceRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Performance>> GetAllPerformancesAsync()
        {
            var performances = await _performanceRepository.GetAllPerformancesAsync();
            return performances;
        }

        public async Task<Performance?> GetPerformanceByIdAsync(Guid id)
        {
            var performance = await _performanceRepository.GetPerformanceByIdAsync(id);
            return performance;
        }

        public async Task<IEnumerable<Performance>> GetPerformancesByGameIdAsync(Guid gameId)
        {
            var performances = await _performanceRepository.GetPerformancesByGameIdAsync(gameId);
            return performances;
        }

        public async Task<IEnumerable<Performance>> GetPerformancesByGraphicsQualityAsync(string graphicsQuality)
        {
            var performances = await _performanceRepository.GetPerformancesByGraphicsQualityAsync(graphicsQuality);
            return performances;
        }
    }
}

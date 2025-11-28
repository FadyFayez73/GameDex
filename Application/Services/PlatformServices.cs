using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class PlatformApplication : IPlatformApplication
    {
        private readonly IPlatformRepository _platformRepository;

        public PlatformApplication(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Platform entity)
        {
            var platform = await _platformRepository.GetPlatformByNameAsync(entity.Name);
            if (platform != null) return (false, Guid.Empty);

            entity.PlatformID = Guid.NewGuid();

            var result = await _platformRepository.AddAsync(entity);

            return (result, entity.PlatformID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var platform = await _platformRepository.GetPlatformByIdAsync(id);
            if (platform == null) return false;

            return await _platformRepository.DeleteAsync(platform);
        }

        public async Task<bool> UpdateAsync(Platform entity)
        {
            var result = await _platformRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            var platforms = await _platformRepository.GetAllPlatformsAsync();
            return platforms;
        }

        public async Task<Platform?> GetPlatformByIdAsync(Guid id)
        {
            var platform = await _platformRepository.GetPlatformByIdAsync(id);
            return platform;
        }

        public async Task<Platform?> GetPlatformByNameAsync(string name)
        {
            var platform = await _platformRepository.GetPlatformByNameAsync(name);
            return platform;
        }
    }
}

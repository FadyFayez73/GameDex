using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _context;

        public PlatformRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Platform platform)
        {
            _context.Platforms.Add(platform);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Platform platform)
        {
            _context.Platforms.Remove(platform);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            var platforms = await _context.Platforms
                .ToListAsync();
            return platforms;
        }

        public async Task<Platform?> GetPlatformByIdAsync(Guid platformId)
        {
            var platform = await _context.Platforms
                .FirstOrDefaultAsync(p => p.PlatformID == platformId);

            return platform;
        }

        public async Task<Platform?> GetPlatformByNameAsync(string name)
        {
            var platform = await _context.Platforms
                .FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
            return platform;
        }

        public async Task<IEnumerable<Platform>> GetPlatformsByIdsAsync(List<Guid> ids)
        {
            var platforms = await _context.Platforms.Where(p => ids.Contains(p.PlatformID))
                .ToListAsync();
            return platforms;
        }

        public async Task<IEnumerable<Platform>> GetPlatformsByNamesAsync(List<string> names)
        {
            var platforms = await _context.Platforms.Where(p => names.Contains(p.Name))
                .ToListAsync();
            return platforms;

        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Platform entity)
        {
            var platform = await _context.Platforms
                .FirstOrDefaultAsync(p => p.PlatformID == entity.PlatformID);

            if (platform == null) return false;

            platform.Name = entity.Name;

            return await SaveChangesAsync();
        }
    }
}

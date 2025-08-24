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
    public class ModManagerRepository : IModManagerRepository
    {
        private AppDbContext _context;

        public ModManagerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ModManager modManager)
        {
            _context.ModManagers.Add(modManager);

            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(ModManager modManager)
        {
            _context.ModManagers.Remove(modManager);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<ModManager>> GetAllModManagersAsync()
        {
            var modManagers = await _context.ModManagers
                .Include(mm => mm.Games)
                .ToListAsync();
            return modManagers;
        }

        public async Task<ModManager?> GetModManagerByIdAsync(Guid id)
        {
            var modManager = await _context.ModManagers
                .Include(mm => mm.Games)
                .FirstOrDefaultAsync(mm => mm.ModManagerID == id);
            
            return modManager;
        }

        public async Task<IEnumerable<ModManager>> GetModManagersByGameIdAsync(Guid gameId)
        {
            var modManagers = await _context.ModManagers
                .Include(mm => mm.Games)
                .Where(mm => mm.Games.Any(g => g.GameID == gameId))
                .ToListAsync();

            return modManagers;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(ModManager entity)
        {
            var modManager = await GetModManagerByIdAsync(entity.ModManagerID);

            if (modManager == null) return false;

            modManager.Path = entity.Path;
            modManager.Description = entity.Description;

            return await SaveChangesAsync();
        }
    }
} 
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
    public class PerformanceRepository : IPerformanceRepository
    {
        private AppDbContext _context;

        public PerformanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Performance performance)
        {
            _context.Performances.Add(performance);

            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Performance performance)
        {
            _context.Performances.Remove(performance);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<Performance>> GetAllPerformancesAsync()
        {
            var performances = await _context.Performances
                .Include(p => p.Game)
                .ToListAsync();
            return performances;
        }

        public async Task<Performance?> GetPerformanceByIdAsync(Guid id)
        {
            var performance = await _context.Performances
                .Include(p => p.Game)
                .FirstOrDefaultAsync(p => p.PerformanceID == id);
            
            return performance;
        }

        public async Task<IEnumerable<Performance>> GetPerformancesByGameIdAsync(Guid gameId)
        {
            var performances = await _context.Performances
                .Include(p => p.Game)
                .Where(p => p.GameID == gameId)
                .ToListAsync();

            return performances;
        }

        public async Task<IEnumerable<Performance>> GetPerformancesByGraphicsQualityAsync(string graphicsQuality)
        {
            var performances = await _context.Performances
                .Include(p => p.Game)
                .Where(p => p.GraphicsQuality == graphicsQuality)
                .ToListAsync();

            return performances;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Performance entity)
        {
            var performance = await GetPerformanceByIdAsync(entity.PerformanceID);

            if (performance == null) return false;

            performance.GraphicsQuality = entity.GraphicsQuality;
            performance.Low1PercentFPS = entity.Low1PercentFPS;
            performance.AverageFPS = entity.AverageFPS;
            performance.MaxFPS = entity.MaxFPS;
            performance.TestDate = entity.TestDate;
            performance.GameID = entity.GameID;

            return await SaveChangesAsync();
        }
    }
} 
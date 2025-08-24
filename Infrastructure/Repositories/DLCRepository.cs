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
    public class DLCRepository : IDLCRepository
    {
        private AppDbContext _context;

        public DLCRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(DLC dlc)
        {
            _context.DLCs.Add(dlc);

            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(DLC dlc)
        {
            _context.DLCs.Remove(dlc);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<DLC>> GetAllDLCsAsync()
        {
            var dlcs = await _context.DLCs
                .Include(d => d.Game)
                .ToListAsync();
            return dlcs;
        }

        public async Task<DLC?> GetDLCByIdAsync(Guid id)
        {
            var dlc = await _context.DLCs
                .Include(d => d.Game)
                .FirstOrDefaultAsync(d => d.DLCID == id);
            
            return dlc;
        }

        public async Task<DLC?> GetDLCByNameAsync(string name)
        {
            var dlc = await _context.DLCs
                .Include(d => d.Game)
                .FirstOrDefaultAsync(d => d.Name == name);

            return dlc;
        }

        public async Task<IEnumerable<DLC>> GetDLCsByGameIdAsync(Guid gameId)
        {
            var dlcs = await _context.DLCs
                .Include(d => d.Game)
                .Where(d => d.GameID == gameId)
                .ToListAsync();

            return dlcs;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(DLC entity)
        {
            var dlc = await GetDLCByIdAsync(entity.DLCID);

            if (dlc == null) return false;

            dlc.Name = entity.Name;
            dlc.Description = entity.Description;
            dlc.GameID = entity.GameID;

            return await SaveChangesAsync();
        }
    }
} 
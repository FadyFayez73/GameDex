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
    public class RequirementRepository : IRequirementRepository
    {
        private AppDbContext _context;

        public RequirementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Requirement requirement)
        {
            _context.Requirements.Add(requirement);

            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Requirement requirement)
        {
            _context.Requirements.Remove(requirement);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<Requirement>> GetAllRequirementsAsync()
        {
            var requirements = await _context.Requirements
                .Include(r => r.Game)
                .ToListAsync();
            return requirements;
        }

        public async Task<Requirement?> GetRequirementByIdAsync(Guid id)
        {
            var requirement = await _context.Requirements
                .Include(r => r.Game)
                .FirstOrDefaultAsync(r => r.RequirementID == id);
            
            return requirement;
        }

        public async Task<IEnumerable<Requirement>> GetRequirementsByGameIdAsync(Guid gameId)
        {
            var requirements = await _context.Requirements
                .Include(r => r.Game)
                .Where(r => r.GameID == gameId)
                .ToListAsync();

            return requirements;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Requirement entity)
        {
            var requirement = await GetRequirementByIdAsync(entity.RequirementID);

            if (requirement == null) return false;

            requirement.RequirementType = entity.RequirementType;
            requirement.SystemOS = entity.SystemOS;
            requirement.Processor = entity.Processor;
            requirement.Memory = entity.Memory;
            requirement.Graphics = entity.Graphics;
            requirement.Network = entity.Network;
            requirement.Storage = entity.Storage;
            requirement.SoundCard = entity.SoundCard;
            requirement.DirectX = entity.DirectX;
            requirement.GameID = entity.GameID;

            return await SaveChangesAsync();
        }
    }
} 
using GameDex.DataLayer;
using GameDex.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.Tools.DataHelper
{
    public class RequirementsHelper : IDataHelper<Requirement>
    {
        private readonly AppDbContext _context;
        public RequirementsHelper(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Requirement model)
        {
            _context.Requirements.Add(model);
            _context.SaveChanges();
        }

        public async Task<List<Requirement>> AdvancedSearchAsync(string word)
        {
            var requirements = await _context.Requirements
                .Where(g =>
                    g.RequirementType.Contains(word)
                )
                .ToListAsync();
            return requirements;
        }

        public async Task<Requirement> GetAllForDisplayAsync(int id)
        {
            var requirement = await _context.Requirements
                .Include(x => x.Game)
                .FirstOrDefaultAsync(g => g.RequirementID == id);
            if (requirement == null)
                throw new Exception("Requirement not found");
            return requirement;
        }

        public async Task<List<Requirement>> GetAllAsync()
        {
            var requirements = await _context.Requirements
                .ToListAsync();
            return requirements;
        }

        public async Task<Requirement> GetByIDAsync(int id)
        {
            var requirement = await _context.Requirements.FirstOrDefaultAsync(g => g.RequirementID == id);
            if (requirement == null)
                throw new Exception("Requirement not found");
            return requirement;
        }

        public void Remove(Requirement model)
        {
            _context.Requirements.Remove(model);
            _context.SaveChanges();
        }

        public void Update(Requirement model)
        {
            _context.Requirements.Update(model);
            _context.SaveChanges();
        }
    }
}

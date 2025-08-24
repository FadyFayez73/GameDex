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
    public class ControlRepository : IControlRepository
    {
        private AppDbContext _context;

        public ControlRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Control control)
        {
            _context.Controls.Add(control);

            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Control control)
        {
            _context.Controls.Remove(control);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<Control>> GetAllControlsAsync()
        {
            var controls = await _context.Controls
                .Include(c => c.Game)
                .ToListAsync();
            return controls;
        }

        public async Task<Control?> GetControlByIdAsync(Guid id)
        {
            var control = await _context.Controls
                .Include(c => c.Game)
                .FirstOrDefaultAsync(c => c.ControlID == id);
            
            return control;
        }

        public async Task<IEnumerable<Control>> GetControlsByGameIdAsync(Guid gameId)
        {
            var controls = await _context.Controls
                .Include(c => c.Game)
                .Where(c => c.GameID == gameId)
                .ToListAsync();

            return controls;
        }

        public async Task<IEnumerable<Control>> GetControlsByTypeAsync(string controlType)
        {
            var controls = await _context.Controls
                .Include(c => c.Game)
                .Where(c => c.ControlType == controlType)
                .ToListAsync();

            return controls;
        }

        public async Task<IEnumerable<Control>> GetControlsByActionAsync(string action)
        {
            var controls = await _context.Controls
                .Include(c => c.Game)
                .Where(c => c.Action == action)
                .ToListAsync();

            return controls;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Control entity)
        {
            var control = await GetControlByIdAsync(entity.ControlID);

            if (control == null) return false;

            control.ControlType = entity.ControlType;
            control.Action = entity.Action;
            control.Key = entity.Key;
            control.GameID = entity.GameID;

            return await SaveChangesAsync();
        }
    }
} 
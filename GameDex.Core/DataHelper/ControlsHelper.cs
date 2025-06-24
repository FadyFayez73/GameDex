using GameDex.DataLayer;
using GameDex.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.Core.DataHelper
{
    public class ControlsHelper : IDataHelper<Control>
    {
        private readonly AppDbContext _context;
        public ControlsHelper(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Control model)
        {
            _context.Controls.Add(model);
            _context.SaveChanges();
        }

        public async Task<List<Control>> AdvancedSearchAsync(string word)
        {
            var controls = await _context.Controls
                .Where(g =>
                    g.Key.Contains(word)
                )
                .ToListAsync();
            return controls;
        }

        public async Task<Control> GetAllForDisplayAsync(int id)
        {
            var control = await _context.Controls
                .Include(x => x.Game)
                .FirstOrDefaultAsync(g => g.ControlID == id);
            if (control == null)
                throw new Exception("Control not found");
            return control;
        }

        public async Task<List<Control>> GetAllAsync()
        {
            var controls = await _context.Controls
                .ToListAsync();
            return controls;
        }

        public async Task<Control> FindByIDAsync(int id)
        {
            var control = await _context.Controls.FirstOrDefaultAsync(g => g.ControlID == id);
            if (control == null)
                throw new Exception("Control not found");
            return control;
        }

        public void Remove(Control model)
        {
            _context.Controls.Remove(model);
            _context.SaveChanges();
        }

        public void Update(Control model)
        {
            _context.Controls.Update(model);
            _context.SaveChanges();
        }
    }
}

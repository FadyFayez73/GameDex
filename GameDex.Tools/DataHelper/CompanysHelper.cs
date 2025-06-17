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
    public class CompanysHelper : IDataHelper<Company>
    {
        private readonly AppDbContext _context;
        public CompanysHelper(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Company model)
        {
            _context.Companys.Add(model);
            _context.SaveChanges();
        }

        public async Task<List<Company>> AdvancedSearchAsync(string word)
        {
            var companys = await _context.Companys
                .Where(g =>
                    g.Name.Contains(word)
                )
                .ToListAsync();
            return companys;
        }

        public async Task<Company> GetAllForDisplayAsync(int id)
        {
            var company = await _context.Companys
                .Include(x => x.Games)
                .FirstOrDefaultAsync(g => g.CompanyID == id);
            if (company == null)
                throw new Exception("Company not found");
            return company;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            var companys = await _context.Companys
                .ToListAsync();
            return companys;
        }

        public async Task<Company> GetByIDAsync(int id)
        {
            var company = await _context.Companys.FirstOrDefaultAsync(g => g.CompanyID == id);
            if (company == null)
                throw new Exception("Company not found");
            return company;
        }

        public void Remove(Company model)
        {
            _context.Companys.Remove(model);
            _context.SaveChanges();
        }

        public void Update(Company model)
        {
            _context.Companys.Update(model);
            _context.SaveChanges();
        }
    }
}

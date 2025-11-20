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
    public class CompanyRepository : ICompanyRepository
    {
        private AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Company company)
        {
            _context.Companies.Add(company);

            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Company company)
        {
            _context.Companies.Remove(company);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            var companies = await _context.Companies
                .ToListAsync();
            return companies;
        }

        public async Task<Company?> GetCompanyByIdAsync(Guid id)
        {
            var company = await _context.Companies
                .FirstOrDefaultAsync(c => c.CompanyID == id);
            
            return company;
        }

        public async Task<Company?> GetCompanyByNameAsync(string name)
        {
            var company = await _context.Companies
                .FirstOrDefaultAsync(c => c.Name == name);

            return company;
        }

        public async Task<IEnumerable<Company>> GetCompaniesByGameIdAsync(Guid gameId)
        {
            var companies = await _context.Companies
                .Where(c => c.CompanyGames.Any(cg => cg.GameID == gameId))
                .ToListAsync();

            return companies;
        }

        public async Task<IEnumerable<Company>> GetCompaniesByRoleAsync(string role)
        {
            var companies = await _context.Companies
                .Where(c => c.CompanyGames.Any(cg => cg.Role.ToString() == role))
                .ToListAsync();

            return companies;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Company entity)
        {
            var company = await GetCompanyByIdAsync(entity.CompanyID);

            if (company == null) return false;

            company.Name = entity.Name;
            company.Description = entity.Description;

            return await SaveChangesAsync();
        }
    }
}

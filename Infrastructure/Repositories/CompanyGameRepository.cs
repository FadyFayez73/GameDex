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
    public class CompanyGameRepository : ICompanyGameRepository
    {
        private readonly AppDbContext _context;

        public CompanyGameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(CompanyGame entity)
        {
            _context.CompanyGames.Add(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(CompanyGame companyGame)
        {
            _context.CompanyGames.Remove(companyGame);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<CompanyGame>> GetAllCompanyGamesAsync()
        {
            var companyGames = await _context.CompanyGames
                .Include(cg => cg.Company)
                .Include(cg => cg.Game)
                .ToListAsync();
            return companyGames;
        }

        public async Task<IEnumerable<Company>> GetCompaniesByGameIdAsync(Guid gameId)
        {
            var companies = await _context.CompanyGames
                .Where(cg => cg.GameID == gameId)
                .Select(cg => cg.Company)
                .ToListAsync();

            return companies;
        }

        public async Task<CompanyGame?> GetCompanyGameByPkAsync(Guid gameId, Guid companyId, CompanyRole companyRole)
        {
            var companyGame = await _context.CompanyGames
                .FirstOrDefaultAsync(cg => cg.GameID == gameId && cg.CompanyID == companyId && cg.Role == companyRole);
            return companyGame;
        }

        public async Task<IEnumerable<Game>> GetGamesByCompanyIdAsync(Guid companyId)
        {
            var games = await _context.CompanyGames
                .Where(cg => cg.CompanyID == companyId)
                .Select(cg => cg.Game)
                .ToListAsync();

            return games;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}

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
    public class GameRepository : IGameRepository
    {
        private AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Game entity)
        {
            _context.Games.Add(entity);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(Game model)
        {
            _context.Games.Remove(model);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Game>> GetAllGamesForDisplayAsync()
        {
            var games = await _context.Games
                .Include(g => g.Medias)
                .Include(g => g.Platforms)
                .Include(g => g.Genres)
                .ToListAsync();
            return games;
        }

        public async Task<Game?> GetGameByIdAsync(Guid id)
        {
            var game = await _context.Games
                .FirstOrDefaultAsync(g => g.GameID == id);
            
            return game;
        }

        public async Task<Game?> GetGameByNameAsync(string name)
        {
            var game = await _context.Games
                .FirstOrDefaultAsync(g => g.Name.Contains(name));

            return game;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Game entity)
        {
            _context.Games.Update(entity);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}

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

        public async Task<IQueryable<Game>> GetAllGamesForDisplayAsync()
        {
            var games = _context.Games
                .Include(g => g.Medias)
                .Include(g => g.Platforms)
                .Include(g => g.Genres)
                .AsQueryable();

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
                .FirstOrDefaultAsync(g => g.Name == name);

            return game;
        }

        public async Task<IEnumerable<Game>> GetGamesByGenreAsync(Guid genreId)
        {
            var games = await _context.Games
                .Where(g => g.Genres != null && g.Genres.Any(genre => genre.GenreID == genreId))
                .ToListAsync();

            return games;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Game entity)
        {
            var game = await GetGameByIdAsync(entity.GameID);

            if (game == null) return false;

            game.Name = entity.Name;
            game.Patch = entity.Patch;
            game.GamePath = entity.GamePath;
            game.YearOfRelease = entity.YearOfRelease;
            game.PGRating = entity.PGRating;
            game.GameDescription = entity.GameDescription;
            game.GameEngine = entity.GameEngine;
            game.OrderOfFranchise = entity.OrderOfFranchise;
            game.LinkForCrack = entity.LinkForCrack;
            game.CriticsRating = entity.CriticsRating;
            game.PlayersRating = entity.PlayersRating;
            game.UserRating = entity.UserRating;
            game.SteamPrices = entity.SteamPrices;
            game.ActualGameSize = entity.ActualGameSize;
            game.GameFiles = entity.GameFiles;
            game.HoursToComplete = entity.HoursToComplete;
            game.PlayerHours = entity.PlayerHours;
            game.StoryPlace = entity.StoryPlace;

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}

using GameDex.DataLayer;
using GameDex.DataLayer.Models;
using GameDex.Tools.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.Tools.DataHelper
{
    public class GamesHelper : IDataHelper<Game>
    {
        private readonly AppDbContext _context;
        public GamesHelper(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Game model)
        {
            _context.Games.Add(model);
            _context.SaveChanges();
        }

        public void Remove(Game model)
        {
            _context.Games.Remove(model);
            _context.SaveChanges();
        }

        public void Update(Game model)
        {
            _context.Games.Update(model);
            _context.SaveChanges();
        }


        public async Task<List<Game>> AdvancedSearchAsync(string word)
        {
            var games = await _context.Games
                .Where(g => 
                    g.Name.Contains(word) ||
                    g.Patch.Contains(word) ||
                    g.YearOfRelease.Contains(word) ||
                    g.PGRating.Contains(word) ||
                    g.GameDescription.Contains(word) ||
                    g.GameEngine.Contains(word) ||
                    g.StoryPlace.Contains(word)
                )
                .ToListAsync();
            return games;
        }

        public async Task<Game> GetGameForDisplayAsync(int id)
        {
            var game = await _context.Games
                .Include(x => x.Albums)
                .Include(x => x.Controls)
                .Include(x => x.Requirements)
                .Include(x => x.Companies)
                .Include(x => x.ModManagers)
                .Include(x => x.Medias)
                .Include(x => x.Platforms)
                .Include(x => x.ChapterMissions)
                .Include(x => x.Characters)
                .Include(x => x.Performances)
                .Include(x => x.Genres)
                .Include(x => x.DLCs)
                .FirstOrDefaultAsync(g => g.GameID == id);
            if (game == null)
                throw new GameNotFoundException(id);
            return game;
        }

        public async Task<List<Game>> GetAllAsync()
        {
            var games = await _context.Games
                .ToListAsync();
            return games;
        }

        public async Task<Game> FindByIDAsync(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.GameID == id);
            if (game == null)
                throw new GameNotFoundException(id);
            return game;
        }

        // Get For Display
        public async Task<List<Game>> GetAllForDisplayAsync()
        {
            var games = await _context.Games
                .Include(x => x.Medias)
                .Include(x => x.Companies)
                .Include(x => x.Genres)
                .ToListAsync();

            return games;
        }

        // // Get Filter For Display

        public async Task<List<Game>> GetGamesOrderedByRatingDisplayAsync()
        {
            var games = await GetAllForDisplayAsync();
            games = games.OrderBy(g => g.UserRating).ToList();
            return games;
        }

        public async Task<List<Game>> GetGamesOrderedByReleaseDateDisplayAsync()
        {
            var games = await GetAllForDisplayAsync();
            games = games.OrderBy(g => g.YearOfRelease).ToList();
            return games;
        }

        public async Task<List<Game>> GetGamesOrderedByNameDisplayAsync()
        {
            var games = await GetAllForDisplayAsync();
            games = games.OrderBy(g => g.Name).ToList();
            return games;
        }

        public async Task<List<Game>> GetGamesOrderedBySizeDisplayAsync()
        {
            var games = await GetAllForDisplayAsync();
            games = games.OrderBy(g => g.ActualGameSize).ToList();
            return games;
        }

        public async Task<List<Game>> SearchByNameDisplayAsync(string name)
        {
            var games = await GetAllForDisplayAsync();
            games = games
                .Where(g => 
                    g.Name.ToLower().Contains(name.ToLower()))
                .ToList();
            return games;
        }
    }
}
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;

namespace Services.Services
{
    public class GameServices : IGameServices
    {
        private readonly IGameRepository _gameRepository;
        public GameServices(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<bool> AddAsync(Game entity)
        {
            var game = await _gameRepository.GetGameByNameAsync(entity.Name);
            if (game != null) return false;
            
            var result = await _gameRepository.AddAsync(entity);

            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var game = await _gameRepository.GetGameByIdAsync(id);
            if (game == null) return false;

            return await _gameRepository.DeleteAsync(game);
        }

        public async Task<IEnumerable<Game>> GetAllGamesForDisplayAsync()
        {
            return await _gameRepository
                .GetAllGamesForDisplayAsync();
        }

        public async Task<Game?> GetGameByIdAsync(Guid id)
        {
            return await _gameRepository
                .GetGameByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Game entity)
        {
            var game = await _gameRepository
                .GetGameByIdAsync(entity.GameID);

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

            return await _gameRepository
                .SaveChangesAsync();
        }
    }
}
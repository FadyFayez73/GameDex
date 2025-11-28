using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Contracts;

namespace Application.Application
{
    public class GameServices : IGameServices
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;

        public GameServices(IGameRepository gameRepository, IGenreRepository genreRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
        }

        /// <summary>
        /// Adds a new game to the repository if a game with the same name does not already exist.
        /// </summary>
        /// <param name="game">Game model from domain to add.</param>
        /// <returns>Tuple: success state and new GameID.</returns>
        public async Task<(bool, Guid)> AddAsync(Game game)
        {

            var existGame = await _gameRepository.GetGameByNameAsync(game.Name);
            if (existGame != null) return (false, Guid.Empty);

            game.GameID = Guid.NewGuid();

            var result = await _gameRepository.AddAsync(game);

            return (result, game.GameID);
        }

        /// <summary>
        /// Deletes a game by its ID if it exists.
        /// </summary>
        /// <param name="id">Unique identifier of the game to delete.</param>
        /// <returns>True if deleted successfully, otherwise false.</returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var game = await _gameRepository.GetGameByIdAsync(id);
            if (game == null) return false;

            return await _gameRepository.DeleteAsync(game);
        }

        /// <summary>
        /// Retrieves all games from the repository.
        /// </summary>
        /// <returns>IEnumerable of all games.</returns>
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            var games = await _gameRepository.GetAllGamesAsync();
            return games;
        }

        /// <summary>
        /// Retrieves all games intended for display.
        /// </summary>
        /// <returns>IEnumerable of games for display.</returns>
        public async Task<IEnumerable<Game>> GetAllGamesForDisplayAsync()
        {
            var games = await _gameRepository
                .GetAllGamesForDisplayAsync();

            return await games.ToListAsync();
        }

        /// <summary>
        /// Fetches a single game by its unique ID.
        /// </summary>
        /// <param name="id">Unique identifier of the game.</param>
        /// <returns>Game if found, otherwise null.</returns>
        public async Task<Game?> GetGameByIdAsync(Guid id)
        {
            var game = await _gameRepository
                .GetGameByIdAsync(id);

            return game;
        }

        /// <summary>
        /// Retrieves all games associated with a specific genre ID.
        /// </summary>
        /// <param name="genreId">Unique identifier of the genre.</param>
        /// <returns>IEnumerable of games for the genre.</returns>
        public async Task<IEnumerable<Game>> GetGamesByGenreIdAsync(Guid genreId)
        {
            var games = await _genreRepository
                .GetGamesByGenreIdAsync(genreId);

            return games;
        }

        /// <summary>
        /// Updates an existing game game in the repository.
        /// </summary>
        /// <param name="game">Game model from domain to update.</param>
        /// <returns>True if update was successful, otherwise false.</returns>
        public async Task<bool> UpdateAsync(Game game)
        {
            var result = await _gameRepository.UpdateAsync(game);
            return result;
        }
    }
}
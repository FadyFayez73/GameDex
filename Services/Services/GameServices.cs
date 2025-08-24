using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;

namespace Services.Services
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

        public async Task<(bool, Guid)> AddAsync(Game entity)
        {
            //var genres = entity.Genres;
            //if (genres != null)
            //{
            //    var genresName = genres.Select(g => g.Name).ToList();

            //    var existsGenres = (await _genreRepository.GetGenreByNamesAsync(genresName)).ToList();

            //    var namesToAdd = genresName.Where(g => !existsGenres.Select(g => g.Name).Contains(g)).ToList();

            //    var toAdd = namesToAdd.Select(name => new Genre
            //    {
            //        GenreID = Guid.NewGuid(),
            //        Name = name
            //    }).ToList();

            //    var addRangeResult = await _genreRepository.AddRangeAsync(toAdd);

            //}

            var game = await _gameRepository.GetGameByNameAsync(entity.Name);
            if (game != null) return (false, Guid.Empty);

            entity.GameID = Guid.NewGuid();

            var result = await _gameRepository.AddAsync(entity);

            return (result, entity.GameID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var game = await _gameRepository.GetGameByIdAsync(id);
            if (game == null) return false;

            return await _gameRepository.DeleteAsync(game);
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            var games = await _gameRepository.GetAllGamesAsync();
            return games;
        }

        public async Task<IEnumerable<Game>> GetAllGamesForDisplayAsync()
        {
            var games = await _gameRepository
                .GetAllGamesForDisplayAsync();

            return await games.ToListAsync();
        }

        public async Task<Game?> GetGameByIdAsync(Guid id)
        {
            var game = await _gameRepository
                .GetGameByIdAsync(id);

            return game;
        }

        public async Task<IEnumerable<Game>> GetGamesByGenreIdAsync(Guid genreId)
        {
            var games = await _genreRepository
                .GetGamesByGenreIdAsync(genreId);

            return games;
        }

        public async Task<bool> UpdateAsync(Game entity)
        {
            var result = await _gameRepository.UpdateAsync(entity);
            return result;
        }
    }
}
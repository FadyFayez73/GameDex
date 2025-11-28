using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Application
{
    public class GenreServices : IGenreServices
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IGameRepository  _gameRepository;


        public GenreServices(IGenreRepository genreRepository, IGameRepository gameRepository)
        {
            _genreRepository = genreRepository;
            _gameRepository = gameRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Genre entity)
        {
            var genre = await _genreRepository.GetGenreByNameAsync(entity.Name);
            if (genre != null) return (false, Guid.Empty);

            entity.GenreID = Guid.NewGuid();

            var result = await _genreRepository.AddAsync(entity);

            return (result, entity.GenreID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(id);
            if (genre == null) return false;

            return await _genreRepository.DeleteAsync(genre);
        }

        public async Task<bool> UpdateAsync(Genre entity)
        {
            var result = await _genreRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.GetAllGenresAsync();
            return genres;
        }

        public async Task<Genre?> GetGenreByIdAsync(Guid id)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(id);
            return genre;
        }

        public async Task<Genre?> GetGenreByNameAsync(string name)
        {
            var genre = await _genreRepository.GetGenreByNameAsync(name);
            return genre;
        }

        public async Task<IEnumerable<Genre>> GetGenresByIdsAsync(List<Guid> ids)
        {
            var genres = await _genreRepository.GetGenresByIdsAsync(ids);
            return genres;
        }

        public async Task<IEnumerable<Genre>> GetGenresByNamesAsync(List<string> names)
        {
            var genres = await _genreRepository.GetGenresByNamesAsync(names);
            return genres;
        }

        public async Task<IEnumerable<Genre>> GetGenresByGameIdAsync(Guid gameId)
        {
            var genres = await _gameRepository.GetGenresByGameIdAsync(gameId);
            return genres;
        }
    }
}

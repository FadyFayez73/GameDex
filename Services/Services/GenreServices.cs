using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Repositories;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class GenreServices : IGenreServices
    {
        private readonly IGenreRepository _genreRepository;
        public GenreServices(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Genre entity)
        {
            var game = await _genreRepository.GetGenreByNameAsync(entity.Name);
            if (game != null) return (false, Guid.Empty);

            entity.GenreID = Guid.NewGuid();
            var result = await _genreRepository.AddAsync(entity);
            if (!result) return (false, Guid.Empty);
            return (result, entity.GenreID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(id);
            if (genre == null) return false;
            var result = await _genreRepository.DeleteAsync(genre);
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

        public async Task<bool> UpdateAsync(Genre entity)
        {
            var result = await _genreRepository.UpdateAsync(entity);
            return result;
        }
    }
}

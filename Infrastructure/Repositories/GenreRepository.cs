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
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Genre entity)
        {
            _context.Genres.Add(entity);

            var result = await _context
                .SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddRangeAsync(List<Genre> genres)
        {
            foreach (var genre in genres) 
                _context.Genres.Add(genre);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(Genre model)
        {
            _context.Genres.Remove(model);
            var result = await _context
                .SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            var genres = await _context.Genres
                .ToListAsync();
            return genres;
        }

        public async Task<Genre?> GetGenreByIdAsync(Guid id)
        {
            var genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.GenreID
                .ToString() == id.ToString());
            return genre;
        }

        public async Task<IEnumerable<Genre>> GetGenreByIdsAsync(List<Guid> ids)
        {
            var genres = await _context.Genres.Where(g => ids.Contains(g.GenreID))
                .ToListAsync();

            return genres;
        }

        public async Task<Genre?> GetGenreByNameAsync(string name)
        {
            var genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Name == name);
            return genre;
        }

        public async Task<IEnumerable<Genre>> GetGenreByNamesAsync(List<string> names)
        {
            var genres = await _context.Genres.Where(g => names.Contains(g.Name))
                .ToListAsync();

            return genres;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context
                .SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Genre entity)
        {
            var genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.GenreID == entity.GenreID);

            if (genre == null) return false;

            genre.Name = entity.Name;
            genre.Description = entity.Description;

            var result = await _context
                .SaveChangesAsync();
            return result > 0;
        }
    }
}

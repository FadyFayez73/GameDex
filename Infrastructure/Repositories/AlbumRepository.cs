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
    public class AlbumRepository : IAlbumRepository
    {
        private AppDbContext _context;

        public AlbumRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Album album)
        {
            _context.Albums.Add(album);

            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Album album)
        {
            _context.Albums.Remove(album);
            return await SaveChangesAsync();
        }

        public async Task<Album?> GetAlbumByIdAsync(Guid id)
        {
            var album = await _context.Albums
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(a => a.AlbumID == id);
            
            return album;
        }

        public async Task<Album?> GetAlbumByNameAsync(string name)
        {
            var album = await _context.Albums
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(a => a.Name == name);

            return album;
        }

        public async Task<IEnumerable<Album>> GetAlbumsByGameIdAsync(Guid gameId)
        {
            var albums = await _context.Albums
                .Include(a => a.Songs)
                .Where(a => a.GameID == gameId)
                .ToListAsync();

            return albums;
        }

        public async Task<IEnumerable<Album>> GetAlbumsByGenreAsync(string genre)
        {
            var albums = await _context.Albums
                .Include(a => a.Songs)
                .Where(a => a.Genre == genre)
                .ToListAsync();

            return albums;
        }

        public async Task<IEnumerable<Album>> GetAlbumsByProducerAsync(string producer)
        {
            var albums = await _context.Albums
                .Include(a => a.Songs)
                .Where(a => a.Producer == producer)
                .ToListAsync();

            return albums;
        }

        public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
        {
            var albums = await _context.Albums
                .Include(a => a.Game)
                .Include(a => a.Songs)
                .ToListAsync();

            return albums;
        }

        public async Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(Guid albumId)
        {
            var songs = await _context.Albums
                .Where(a => a.AlbumID == albumId)
                .SelectMany(a => a.Songs)
                .ToListAsync();

            return songs;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Album entity)
        {
            var album = await GetAlbumByIdAsync(entity.AlbumID);

            if (album == null) return false;

            album.Name = entity.Name;
            album.Producer = entity.Producer;
            album.Language = entity.Language;
            album.Length = entity.Length;
            album.Genre = entity.Genre;
            album.ReleaseDate = entity.ReleaseDate;
            album.GameID = entity.GameID;

            return await SaveChangesAsync();
        }
    }
} 
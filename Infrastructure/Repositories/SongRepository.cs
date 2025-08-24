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
    public class SongRepository : ISongRepository
    {
        private AppDbContext _context;

        public SongRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Song song)
        {
            _context.Songs.Add(song);

            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Song song)
        {
            _context.Songs.Remove(song);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<Song>> GetAllSongsAsync()
        {
            var songs = await _context.Songs
                .Include(s => s.Album)
                .ToListAsync();
            return songs;
        }

        public async Task<Song?> GetSongByIdAsync(Guid id)
        {
            var song = await _context.Songs
                .Include(s => s.Album)
                .FirstOrDefaultAsync(s => s.SongID == id);
            
            return song;
        }

        public async Task<Song?> GetSongByNameAsync(string name)
        {
            var song = await _context.Songs
                .Include(s => s.Album)
                .FirstOrDefaultAsync(s => s.Name == name);

            return song;
        }

        public async Task<IEnumerable<Song>> GetSongsByDiscNumberAsync(int discNumber)
        {
            var songs = await _context.Songs
                .Include(s => s.Album)
                .Where(s => s.DiscNumber == discNumber)
                .ToListAsync();

            return songs;
        }

        public async Task<IEnumerable<Song>> GetSongsByTrackNumberAsync(int trackNumber)
        {
            var songs = await _context.Songs
                .Include(s => s.Album)
                .Where(s => s.TrackNumber == trackNumber)
                .ToListAsync();

            return songs;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Song entity)
        {
            var song = await GetSongByIdAsync(entity.SongID);

            if (song == null) return false;

            song.Name = entity.Name;
            song.DiscNumber = entity.DiscNumber;
            song.TrackNumber = entity.TrackNumber;
            song.Detail = entity.Detail;
            song.AlbumID = entity.AlbumID;

            return await SaveChangesAsync();
        }
    }
} 
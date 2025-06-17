using GameDex.DataLayer;
using GameDex.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.Tools.DataHelper
{
    public class SongsHelper : IDataHelper<Song>
    {
        private readonly AppDbContext _context;
        public SongsHelper(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Song model)
        {
            _context.Songs.Add(model);
            _context.SaveChanges();
        }

        public async Task<List<Song>> AdvancedSearchAsync(string word)
        {
            var songs = await _context.Songs
                .Where(g =>
                    g.Name.Contains(word)
                )
                .ToListAsync();
            return songs;
        }

        public async Task<Song> GetAllForDisplayAsync(int id)
        {
            var song = await _context.Songs
                .Include(x => x.Album)
                .FirstOrDefaultAsync(g => g.SongID == id);
            if (song == null)
                throw new Exception("Song not found");
            return song;
        }

        public async Task<List<Song>> GetAllAsync()
        {
            var songs = await _context.Songs
                .ToListAsync();
            return songs;
        }

        public async Task<Song> GetByIDAsync(int id)
        {
            var song = await _context.Songs.FirstOrDefaultAsync(g => g.SongID == id);
            if (song == null)
                throw new Exception("Song not found");
            return song;
        }

        public void Remove(Song model)
        {
            _context.Songs.Remove(model);
            _context.SaveChanges();
        }

        public void Update(Song model)
        {
            _context.Songs.Update(model);
            _context.SaveChanges();
        }
    }
}

using GameDex.Core.DataHelper;
using GameDex.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;

namespace AlbumDex.Core.DataHelper
{
    public class AlbumsHelper : IDataHelper<Album>
    {
        private readonly AppDbContext _context;
        public AlbumsHelper(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Album model)
        {
            _context.Albums.Add(model);
            _context.SaveChanges();
        }

        public async Task<List<Album>> AdvancedSearchAsync(string word)
        {
            var albums = await _context.Albums
                .Where(g => 
                    g.Name.Contains(word)
                )
                .ToListAsync();
            return albums;
        }

        public async Task<Album> GetAllForDisplayAsync(int id)
        {
            var album = await _context.Albums
                .Include(x => x.Songs)
                .FirstOrDefaultAsync(g => g.AlbumID == id);
            if (album == null)
                throw new Exception("Album not found");
            return album;
        }

        public async Task<List<Album>> GetAllAsync()
        {
            var albums = await _context.Albums
                .ToListAsync();
            return albums;
        }

        public async Task<Album> FindByIDAsync(int id)
        {
            var album = await _context.Albums.FirstOrDefaultAsync(g => g.AlbumID == id);
            if (album == null)
                throw new Exception("Album not found");
            return album;
        }

        public void Remove(Album model)
        {
            _context.Albums.Remove(model);
            _context.SaveChanges();
        }

        public void Update(Album model)
        {
            _context.Albums.Update(model);
            _context.SaveChanges();
        }
    }
}

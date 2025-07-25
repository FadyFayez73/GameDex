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
    public class MediaRepository : IMediaRepository
    {
        private readonly AppDbContext _context;
        public MediaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Media entity)
        {
            entity.MediaID = Guid.NewGuid();
            _context.Medias.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(Media model)
        {
            _context.Medias.Remove(model);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public Task<Media?> GetMediaByIdAsync(Guid id)
        {
            var media = _context.Medias
                .FirstOrDefaultAsync(m => m.MediaID == id);
            return media;
        }

        public async Task<IEnumerable<Media>> GetMediasByGameIdAsync(Guid gameId)
        {
            var medias = await _context.Medias
                .Where(m => m.GameID == gameId)
                .ToListAsync();

            return medias;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Media entity)
        {
            var media = await GetMediaByIdAsync(entity.MediaID);

            if (media == null) return false;

            media.MediaType = entity.MediaType;
            media.MediaPath = entity.MediaPath;
            media.GameID = entity.GameID;

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}

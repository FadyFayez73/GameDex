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

        public async Task<bool> DeleteAsync(Guid id)
        {
            var media = await _context.Medias.FirstOrDefaultAsync(m => m.MediaID == id);
            if (media == null) return false;
            _context.Medias.Remove(media);
            var result = await _context.SaveChangesAsync();
            return result > 0;
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

        public Task<bool> UpdateAsync(Media entity)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class ChapterMissionRepository : IChapterMissionRepository
    {
        private AppDbContext _context;

        public ChapterMissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ChapterMission chapterMission)
        {
            _context.ChapterMissions.Add(chapterMission);

            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(ChapterMission chapterMission)
        {
            _context.ChapterMissions.Remove(chapterMission);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<ChapterMission>> GetAllChapterMissionsAsync()
        {
            var chapterMissions = await _context.ChapterMissions
                .Include(cm => cm.Game)
                .Include(cm => cm.Characters)
                .ToListAsync();
            return chapterMissions;
        }

        public async Task<ChapterMission?> GetChapterMissionByIdAsync(Guid id)
        {
            var chapterMission = await _context.ChapterMissions
                .Include(cm => cm.Game)
                .Include(cm => cm.Characters)
                .FirstOrDefaultAsync(cm => cm.ChapterMissionID == id);
            
            return chapterMission;
        }

        public async Task<ChapterMission?> GetChapterMissionByNameAsync(string name)
        {
            var chapterMission = await _context.ChapterMissions
                .Include(cm => cm.Game)
                .Include(cm => cm.Characters)
                .FirstOrDefaultAsync(cm => cm.Name == name);

            return chapterMission;
        }

        public async Task<IEnumerable<ChapterMission>> GetChapterMissionsByGameIdAsync(Guid gameId)
        {
            var chapterMissions = await _context.ChapterMissions
                .Include(cm => cm.Game)
                .Include(cm => cm.Characters)
                .Where(cm => cm.GameID == gameId)
                .ToListAsync();

            return chapterMissions;
        }

        public async Task<IEnumerable<ChapterMission>> GetChapterMissionsByTypeAsync(string type)
        {
            var chapterMissions = await _context.ChapterMissions
                .Include(cm => cm.Game)
                .Include(cm => cm.Characters)
                .Where(cm => cm.Type == type)
                .ToListAsync();

            return chapterMissions;
        }

        public async Task<IEnumerable<Character>> GetCharactersByChapterMissionIdAsync(Guid chapterMissionId)
        {
            var characters = await _context.ChapterMissions
                .Where(cm => cm.ChapterMissionID == chapterMissionId)
                .SelectMany(cm => cm.Characters)
                .ToListAsync();

            return characters;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(ChapterMission entity)
        {
            var chapterMission = await GetChapterMissionByIdAsync(entity.ChapterMissionID);

            if (chapterMission == null) return false;

            chapterMission.Type = entity.Type;
            chapterMission.Name = entity.Name;
            chapterMission.Description = entity.Description;
            chapterMission.GameID = entity.GameID;

            return await SaveChangesAsync();
        }
    }
} 
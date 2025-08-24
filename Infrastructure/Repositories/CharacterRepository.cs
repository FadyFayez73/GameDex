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
    public class CharacterRepository : ICharacterRepository
    {
        private AppDbContext _context;

        public CharacterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Character character)
        {
            _context.Characters.Add(character);

            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Character character)
        {
            _context.Characters.Remove(character);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            var characters = await _context.Characters
                .Include(c => c.Game)
                .Include(c => c.ChapterMissions)
                .ToListAsync();

            return characters;
        }

        public async Task<Character?> GetCharacterByIdAsync(Guid id)
        {
            var character = await _context.Characters
                .Include(c => c.Game)
                .Include(c => c.ChapterMissions)
                .FirstOrDefaultAsync(c => c.CharacterID == id);
            
            return character;
        }

        public async Task<Character?> GetCharacterByNameAsync(string name)
        {
            var character = await _context.Characters
                .Include(c => c.Game)
                .Include(c => c.ChapterMissions)
                .FirstOrDefaultAsync(c => c.Name == name);

            return character;
        }

        public async Task<IEnumerable<Character>> GetCharactersByGameIdAsync(Guid gameId)
        {
            var characters = await _context.Characters
                .Include(c => c.Game)
                .Include(c => c.ChapterMissions)
                .Where(c => c.GameID == gameId)
                .ToListAsync();

            return characters;
        }

        public async Task<IEnumerable<ChapterMission>> GetChapterMissionsByCharacterIdAsync(Guid characterId)
        {
            var chapterMissions = await _context.Characters
                .Where(c => c.CharacterID == characterId)
                .SelectMany(c => c.ChapterMissions)
                .ToListAsync();

            return chapterMissions;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Character entity)
        {
            var character = await GetCharacterByIdAsync(entity.CharacterID);

            if (character == null) return false;

            character.Name = entity.Name;
            character.ImagePath = entity.ImagePath;
            character.Description = entity.Description;
            character.GameID = entity.GameID;

            return await SaveChangesAsync();
        }
    }
}

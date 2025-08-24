using Domain.Repositories.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICharacterRepository : IBaseRepository<Character>
    {
        Task<IEnumerable<Character>> GetAllCharactersAsync();
        Task<Character?> GetCharacterByIdAsync(Guid id);
        Task<Character?> GetCharacterByNameAsync(string name);
        Task<IEnumerable<Character>> GetCharactersByGameIdAsync(Guid gameId);
        Task<IEnumerable<ChapterMission>> GetChapterMissionsByCharacterIdAsync(Guid characterId);
    }
}

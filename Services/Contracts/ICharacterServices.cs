using Domain.Entities;
using Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICharacterServices : IBaseServices<Character>
    {
        Task<IEnumerable<Character>> GetAllCharactersAsync();
        Task<Character?> GetCharacterByIdAsync(Guid id);
        Task<Character?> GetCharacterByNameAsync(string name);
        Task<IEnumerable<Character>> GetCharactersByGameIdAsync(Guid gameId);
        Task<IEnumerable<ChapterMission>> GetChapterMissionsByCharacterIdAsync(Guid characterId);
    }
}

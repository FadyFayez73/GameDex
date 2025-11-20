using Domain.Entities;
using Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IChapterMissionServices : IBaseServices<ChapterMission>
    {
        Task<IEnumerable<ChapterMission>> GetAllChapterMissionsAsync();
        Task<ChapterMission?> GetChapterMissionByIdAsync(Guid id);
        Task<ChapterMission?> GetChapterMissionByNameAsync(string name);
        Task<IEnumerable<ChapterMission>> GetChapterMissionsByTypeAsync(string type);
        Task<IEnumerable<Character>> GetCharactersByChapterMissionIdAsync(Guid chapterMissionId);
    }
}

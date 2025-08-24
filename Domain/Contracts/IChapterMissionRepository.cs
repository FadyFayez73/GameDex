using Domain.Repositories.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IChapterMissionRepository : IBaseRepository<ChapterMission>
    {
        Task<IEnumerable<ChapterMission>> GetAllChapterMissionsAsync();
        Task<ChapterMission?> GetChapterMissionByIdAsync(Guid id);
        Task<ChapterMission?> GetChapterMissionByNameAsync(string name);
        Task<IEnumerable<ChapterMission>> GetChapterMissionsByTypeAsync(string type);
        Task<IEnumerable<Character>> GetCharactersByChapterMissionIdAsync(Guid chapterMissionId);
    }
} 
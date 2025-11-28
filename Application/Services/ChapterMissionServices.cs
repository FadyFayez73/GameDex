using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Application
{
    public class ChapterMIssionServices : IChapterMissionServices
    {
        private readonly IChapterMissionRepository _chapterMissionRepository;

        public ChapterMIssionServices(IChapterMissionRepository chapterMissionRepository)
        {
            _chapterMissionRepository = chapterMissionRepository;
        }

        public async Task<(bool, Guid)> AddAsync(ChapterMission entity)
        {
            var chapterMission = await _chapterMissionRepository.GetChapterMissionByNameAsync(entity.Name);
            if (chapterMission != null) return (false, Guid.Empty);

            entity.ChapterMissionID = Guid.NewGuid();

            var result = await _chapterMissionRepository.AddAsync(entity);

            return (result, entity.ChapterMissionID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var chapterMission = await _chapterMissionRepository.GetChapterMissionByIdAsync(id);
            if (chapterMission == null) return false;

            return await _chapterMissionRepository.DeleteAsync(chapterMission);
        }

        public async Task<bool> UpdateAsync(ChapterMission entity)
        {
            var result = await _chapterMissionRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<ChapterMission>> GetAllChapterMissionsAsync()
        {
            var chapterMissions = await _chapterMissionRepository.GetAllChapterMissionsAsync();
            return chapterMissions;
        }

        public async Task<ChapterMission?> GetChapterMissionByIdAsync(Guid id)
        {
            var chapterMission = await _chapterMissionRepository.GetChapterMissionByIdAsync(id);
            return chapterMission;
        }

        public async Task<ChapterMission?> GetChapterMissionByNameAsync(string name)
        {
            var chapterMission = await _chapterMissionRepository.GetChapterMissionByNameAsync(name);
            return chapterMission;
        }

        public async Task<IEnumerable<ChapterMission>> GetChapterMissionsByTypeAsync(string type)
        {
            var chapterMissions = await _chapterMissionRepository.GetChapterMissionsByTypeAsync(type);
            return chapterMissions;
        }

        public async Task<IEnumerable<Character>> GetCharactersByChapterMissionIdAsync(Guid chapterMissionId)
        {
            var characters = await _chapterMissionRepository.GetCharactersByChapterMissionIdAsync(chapterMissionId);
            return characters;
        }
    }
}

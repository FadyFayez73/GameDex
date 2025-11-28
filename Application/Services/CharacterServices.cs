using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Application
{
    public class CharacterServices : ICharacterServices
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterServices(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Character entity)
        {
            var character = await _characterRepository.GetCharacterByNameAsync(entity.Name);
            if (character != null) return (false, Guid.Empty);

            entity.CharacterID = Guid.NewGuid();

            var result = await _characterRepository.AddAsync(entity);

            return (result, entity.CharacterID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var character = await _characterRepository.GetCharacterByIdAsync(id);
            if (character == null) return false;

            return await _characterRepository.DeleteAsync(character);
        }

        public async Task<bool> UpdateAsync(Character entity)
        {
            var result = await _characterRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            var characters = await _characterRepository.GetAllCharactersAsync();
            return characters;
        }

        public async Task<Character?> GetCharacterByIdAsync(Guid id)
        {
            var character = await _characterRepository.GetCharacterByIdAsync(id);
            return character;
        }

        public async Task<Character?> GetCharacterByNameAsync(string name)
        {
            var character = await _characterRepository.GetCharacterByNameAsync(name);
            return character;
        }

        public async Task<IEnumerable<Character>> GetCharactersByGameIdAsync(Guid gameId)
        {
            var characters = await _characterRepository.GetCharactersByGameIdAsync(gameId);
            return characters;
        }

        public async Task<IEnumerable<ChapterMission>> GetChapterMissionsByCharacterIdAsync(Guid characterId)
        {
            var chapterMissions = await _characterRepository.GetChapterMissionsByCharacterIdAsync(characterId);
            return chapterMissions;
        }
    }
}
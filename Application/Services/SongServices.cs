using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Application
{
    public class SongServices : ISongServices
    {
        private readonly ISongRepository _songRepository;

        public SongServices(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Song entity)
        {
            var song = await _songRepository.GetSongByNameAsync(entity.Name);
            if (song != null) return (false, Guid.Empty);

            entity.SongID = Guid.NewGuid();

            var result = await _songRepository.AddAsync(entity);

            return (result, entity.SongID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var song = await _songRepository.GetSongByIdAsync(id);
            if (song == null) return false;

            return await _songRepository.DeleteAsync(song);
        }

        public async Task<bool> UpdateAsync(Song entity)
        {
            var result = await _songRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Song>> GetAllSongsAsync()
        {
            var songs = await _songRepository.GetAllSongsAsync();
            return songs;
        }

        public async Task<Song?> GetSongByIdAsync(Guid id)
        {
            var song = await _songRepository.GetSongByIdAsync(id);
            return song;
        }

        public async Task<Song?> GetSongByNameAsync(string name)
        {
            var song = await _songRepository.GetSongByNameAsync(name);
            return song;
        }

        public async Task<IEnumerable<Song>> GetSongsByDiscNumberAsync(int discNumber)
        {
            var songs = await _songRepository.GetSongsByDiscNumberAsync(discNumber);
            return songs;
        }

        public async Task<IEnumerable<Song>> GetSongsByTrackNumberAsync(int trackNumber)
        {
            var songs = await _songRepository.GetSongsByTrackNumberAsync(trackNumber);
            return songs;
        }
    }
}

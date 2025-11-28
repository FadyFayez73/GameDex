using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Application
{
    public class AlbumServices : IAlbumServices
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumServices(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Album entity)
        {
            var album = await _albumRepository.GetAlbumByNameAsync(entity.Name);
            if (album != null) return (false, Guid.Empty);

            entity.AlbumID = Guid.NewGuid();

            var result = await _albumRepository.AddAsync(entity);

            return (result, entity.AlbumID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(id);
            if (album == null) return false;

            return await _albumRepository.DeleteAsync(album);
        }

        public async Task<bool> UpdateAsync(Album entity)
        {
            var result = await _albumRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
        {
            var albums = await _albumRepository.GetAllAlbumsAsync();
            return albums;
        }

        public async Task<Album?> GetAlbumByIdAsync(Guid id)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(id);
            return album;
        }

        public async Task<Album?> GetAlbumByNameAsync(string name)
        {
            var album = await _albumRepository.GetAlbumByNameAsync(name);
            return album;
        }

        public async Task<IEnumerable<Album>> GetAlbumsByGameIdAsync(Guid gameId)
        {
            var albums = await _albumRepository.GetAlbumsByGameIdAsync(gameId);
            return albums;
        }

        public async Task<IEnumerable<Album>> GetAlbumsByGenreAsync(string genre)
        {
            var albums = await _albumRepository.GetAlbumsByGenreAsync(genre);
            return albums;
        }

        public async Task<IEnumerable<Album>> GetAlbumsByProducerAsync(string producer)
        {
            var albums = await _albumRepository.GetAlbumsByProducerAsync(producer);
            return albums;
        }

        public async Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(Guid albumId)
        {
            var songs = await _albumRepository.GetSongsByAlbumIdAsync(albumId);
            return songs;
        }
    }
}

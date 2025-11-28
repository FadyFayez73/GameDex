using Domain.Entities;
using Domain.Repositories;
using Application.Contracts;

namespace Application.Application
{
    public class MediaApplication : IMediaApplication
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaApplication(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Media entity)
        {
            entity.MediaID = Guid.NewGuid();

            var result = await _mediaRepository.AddAsync(entity);

            return (result, entity.MediaID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var media = await _mediaRepository.GetMediaByIdAsync(id);
            if (media == null) return false;

            return await _mediaRepository.DeleteAsync(media);
        }

        public async Task<bool> UpdateAsync(Media entity)
        {
            var result = await _mediaRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Media>> GetAllMediasAsync()
        {
            var medias = await _mediaRepository.GetAllMediasAsync();
            return medias;
        }

        public async Task<Media?> GetMediaByIdAsync(Guid id)
        {
            var media = await _mediaRepository.GetMediaByIdAsync(id);
            return media;
        }

        public async Task<IEnumerable<Media>> GetMediasByGameIdAsync(Guid gameId)
        {
            var medias = await _mediaRepository.GetMediasByGameIdAsync(gameId);
            return medias;
        }
    }
}
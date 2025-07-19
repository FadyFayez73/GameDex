using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MediaServices : IMediaServices
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IGameRepository _gameRepository;

        public MediaServices(IMediaRepository mediaRepository, IGameRepository gameRepository)
        {
            _mediaRepository = mediaRepository;
            _gameRepository = gameRepository;
        }

        public async Task<bool> AddAsync(Media entity)
        {
            var game = await _gameRepository.GetGameByIdAsync(entity.GameID);
            if (game == null) return false;
            var result = await _mediaRepository.AddAsync(entity);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var media = await _mediaRepository.GetMediaByIdAsync(id);
            if (media == null) return false;

            return await _mediaRepository.DeleteAsync(media);
        }

        public Task<Media?> GetMediaByIdAsync(Guid id)
        {
            var media = _mediaRepository.GetMediaByIdAsync(id);
            return media;
        }

        public async Task<IEnumerable<Media>> GetMediasByGameIdAsync(Guid gameId)
        {
            var medias = await _mediaRepository.GetMediasByGameIdAsync(gameId);
            return medias;
        }

        public async Task<bool> UpdateAsync(Media entity)
        {
            var media = await _mediaRepository.GetMediaByIdAsync(entity.MediaID);

            if(media == null) return false;

            media.MediaType = entity.MediaType;
            media.MediaPath = entity.MediaPath;
            media.GameID = entity.GameID;

            return await _mediaRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateListAsync(List<Media> entities)
        {
            if (entities == null || !entities.Any()) return false;

            var gameId = entities.Select(g => g.GameID).FirstOrDefault();

            var game = (await _gameRepository.GetAllGamesForDisplayAsync()).FirstOrDefault(g => g.GameID == gameId);

            if(game == null) return false;

            if(game.Medias == null) return false;

            var toRemove = game.Medias.Where(m => !entities.Contains(m)).ToList();
            foreach (var entity in toRemove)
                game.Medias.Remove(entity);

            var toAdd = entities.Where(m => !game.Medias.Contains(m)).ToList();
            foreach(var entity in toAdd)
            {
                entity.MediaID = Guid.NewGuid();
                game.Medias.Add(entity);
            }

            foreach (var entity in entities)
            {
                var media = await _mediaRepository.GetMediaByIdAsync(entity.MediaID);
                if (media == null) return false;

                media.MediaType = entity.MediaType;
                media.MediaPath = entity.MediaPath;
                media.GameID = entity.GameID;
            }

            return await _mediaRepository.SaveChangesAsync();
        }
    }
}
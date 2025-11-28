using AutoMapper;
using Application.Features.Games.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using Application.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Queries.Handlers
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, (bool, Guid)>
    {
        private readonly IGameApplication _gameApplication;
        private readonly IMediaApplication _mediaApplication;
        private readonly IMapper _mapper;

        private readonly string _coverFileName = "Cover.jpg";

        public CreateGameCommandHandler(IGameApplication gameApplication, IMediaApplication mediaApplication, IMapper mapper)
        {
            _gameApplication = gameApplication;
            _mediaApplication = mediaApplication;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var gameDomainModel = _mapper.Map<Game>(request);

            if(gameDomainModel == null) 
                throw new ArgumentNullException(nameof(gameDomainModel), "Game domain model cannot be null");
            
            var (gameState, gameId) = await _gameApplication.AddAsync(gameDomainModel);
            
            if (!gameState) 
                return (false, Guid.Empty);

            var currentDirectory = Directory.GetCurrentDirectory();
            var baseFolder = Directory.GetParent(currentDirectory);
            var contentPath = Path.Combine("Content", request.Name);
            var fullPath = Path.Combine(baseFolder.FullName, contentPath);
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
            var fileName = Path.Combine(fullPath, _coverFileName);
            using (var cover = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var bytes = request.Cover.ToArray();
                await cover.WriteAsync(bytes);
            }
            var relativePath = Path.Combine(contentPath, _coverFileName);
            var mediaModel = new Media
            {
                MediaPath = relativePath,
                MediaType = "Cover",
                GameID = gameId
            };

            var (mediaState, mediaId) = await _mediaApplication.AddAsync(mediaModel);

            return (true, Guid.Empty);
        }
    }
}
 
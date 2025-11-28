using AutoMapper;
using Core.Dtos.Games;
using Core.Features.Games.Queries.Commands;
using Core.Features.Medias.Queries.Commands;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Games.Queries.Handlers
{
    public class GetGameByIdCommandHandler : IRequestHandler<GetGameByIdCommand, GameDto?>
    {
        private readonly IGameServices _gameServices;
        private readonly IMapper _mapper;

        public GetGameByIdCommandHandler(IGameServices gameServices, IMapper mapper)
        {
            _gameServices = gameServices;
            _mapper = mapper;
        }

        public async Task<GameDto?> Handle(GetGameByIdCommand request, CancellationToken cancellationToken)
        {
            var game = _mapper.Map<GameDto>(await _gameServices
                .GetGameByIdAsync(request.GameID));

            return game;
        }
    }
}
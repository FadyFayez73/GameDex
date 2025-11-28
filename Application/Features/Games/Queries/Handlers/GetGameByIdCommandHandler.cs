using AutoMapper;
using Application.Dtos.Games;
using Application.Features.Games.Queries.Commands;
using Application.Features.Medias.Queries.Commands;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Queries.Handlers
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
using AutoMapper;
using Application.Dtos.Games;
using Application.Features.Games.Queries.Commands;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Queries.Handlers
{
    public class GetGameForDisplayCommandHandler : IRequestHandler<GetGameForDisplayCommand, GameForDisplayDto?>
    {
        private readonly IGameServices _gameServices;
        private readonly IMapper _mapper;

        public GetGameForDisplayCommandHandler(IGameServices gameServices, IMapper mapper)
        {
            _gameServices = gameServices;
            _mapper = mapper;
        }

        public async Task<GameForDisplayDto?> Handle(GetGameForDisplayCommand request, CancellationToken cancellationToken)
        {
            var gameDomain = await _gameServices.GetGameByIdAsync(request.GameID);
            var gameDto = _mapper.Map<GameForDisplayDto>(gameDomain);
            return gameDto;
        }
    }
}

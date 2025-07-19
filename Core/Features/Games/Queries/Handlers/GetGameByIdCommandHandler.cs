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
    public class GetGameByIdCommandHandler : IRequestHandler<GetGameByIdCommand, GameForDisplayDto>
    {
        private readonly IGameServices _gameServices;
        private readonly IMapper _mapper;
        public GetGameByIdCommandHandler(IGameServices gameServices, IMapper mapper)
        {
            _gameServices = gameServices;
            _mapper = mapper;
        }

        public async Task<GameForDisplayDto> Handle(GetGameByIdCommand request, CancellationToken cancellationToken)
        {
            var game = _mapper.Map<GameForDisplayDto>(await _gameServices
                .GetGameByIdAsync(request.Id));
            return game;
        }
    }
}
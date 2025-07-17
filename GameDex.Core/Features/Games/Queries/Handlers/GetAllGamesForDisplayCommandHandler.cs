using AutoMapper;
using Core.Dtos.Games;
using Core.Features.Games.Queries.Commands;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Games.Queries.Handlers
{
    public class GetAllGamesForDisplayCommandHandler 
        : IRequestHandler<GetAllGamesForDisplayCommand, IEnumerable<GameFroDisplayDto>>
    {
        private readonly IGameServices _gameServices;
        private readonly IMapper _mapper;
        public GetAllGamesForDisplayCommandHandler(IGameServices gameServices, IMapper mapper)
        {
            _gameServices = gameServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameFroDisplayDto>> Handle(GetAllGamesForDisplayCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<GameFroDisplayDto>>(await _gameServices
                .GetAllGamesForDisplayAsync());
        }
    }
}

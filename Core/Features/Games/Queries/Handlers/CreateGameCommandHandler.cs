using AutoMapper;
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
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, (bool, Guid)>
    {
        private readonly IGameServices _gameServices;
        private readonly IMapper _mapper;

        public CreateGameCommandHandler(IGameServices gameServices, IMapper mapper)
        {
            _gameServices = gameServices;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var gameDomainModel = _mapper.Map<Game>(request);
            if(gameDomainModel == null) throw new ArgumentNullException(nameof(gameDomainModel), "Game domain model cannot be null");
            
            var result = await _gameServices.AddAsync(gameDomainModel);

            return result;
        }
    }
}
 
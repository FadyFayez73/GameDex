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
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, bool>
    {
        private readonly IGameServices _gameServices;
        private readonly IMapper _mapper;
        public UpdateGameCommandHandler(IGameServices gameServices, IMapper mapper)
        {
            _gameServices = gameServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var gameDomainModel = _mapper.Map<Game>(request);

            if (gameDomainModel == null)
                throw new ArgumentNullException(nameof(gameDomainModel), "cant convert from \"Update Command\" to \"Domain Model\"!");

            var result = await _gameServices.UpdateAsync(gameDomainModel);
            return result;
        }
    }
}

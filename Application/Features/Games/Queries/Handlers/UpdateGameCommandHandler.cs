using AutoMapper;
using Application.Features.Games.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Queries.Handlers
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, bool>
    {
        private readonly IGameApplication _gameApplication;
        private readonly IMapper _mapper;
        public UpdateGameCommandHandler(IGameApplication gameApplication, IMapper mapper)
        {
            _gameApplication = gameApplication;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var gameDomainModel = _mapper.Map<Game>(request);

            if (gameDomainModel == null)
                throw new ArgumentNullException(nameof(gameDomainModel), "cant convert from \"Update Command\" to \"Domain Model\"!");

            var result = await _gameApplication.UpdateAsync(gameDomainModel);
            return result;
        }
    }
}

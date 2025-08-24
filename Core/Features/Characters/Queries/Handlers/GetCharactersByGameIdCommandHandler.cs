using AutoMapper;
using Core.Dtos.Characters;
using Core.Features.Characters.Queries.Commands;
using MediatR;
using Services.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Characters.Queries.Handlers
{
    public class GetCharactersByGameIdCommandHandler : IRequestHandler<GetCharactersByGameIdCommand, IEnumerable<CharacterDto>>
    {
        private readonly ICharacterServices _characterServices;
        private readonly IMapper _mapper;

        public GetCharactersByGameIdCommandHandler(ICharacterServices characterServices, IMapper mapper)
        {
            _characterServices = characterServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CharacterDto>> Handle(GetCharactersByGameIdCommand request, CancellationToken cancellationToken)
        {
            var characters = await _characterServices.GetCharactersByGameIdAsync(request.GameId);
            var characterDtos = _mapper.Map<IEnumerable<CharacterDto>>(characters);
            return characterDtos;
        }
    }
}


using AutoMapper;
using Application.Dtos.Characters;
using Application.Features.Characters.Queries.Commands;
using MediatR;
using Application.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Characters.Queries.Handlers
{
    public class GetAllCharactersCommandHandler : IRequestHandler<GetAllCharactersCommand, IEnumerable<CharacterDto>>
    {
        private readonly ICharacterServices _characterServices;
        private readonly IMapper _mapper;

        public GetAllCharactersCommandHandler(ICharacterServices characterServices, IMapper mapper)
        {
            _characterServices = characterServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CharacterDto>> Handle(GetAllCharactersCommand request, CancellationToken cancellationToken)
        {
            var characters = await _characterServices.GetAllCharactersAsync();
            var characterDtos = _mapper.Map<IEnumerable<CharacterDto>>(characters);
            return characterDtos;
        }
    }
}


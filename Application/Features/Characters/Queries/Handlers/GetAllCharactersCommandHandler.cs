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
        private readonly ICharacterApplication _characterApplication;
        private readonly IMapper _mapper;

        public GetAllCharactersCommandHandler(ICharacterApplication characterApplication, IMapper mapper)
        {
            _characterApplication = characterApplication;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CharacterDto>> Handle(GetAllCharactersCommand request, CancellationToken cancellationToken)
        {
            var characters = await _characterApplication.GetAllCharactersAsync();
            var characterDtos = _mapper.Map<IEnumerable<CharacterDto>>(characters);
            return characterDtos;
        }
    }
}


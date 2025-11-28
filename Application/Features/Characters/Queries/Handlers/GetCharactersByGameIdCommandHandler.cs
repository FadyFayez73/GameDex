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
    public class GetCharactersByGameIdCommandHandler : IRequestHandler<GetCharactersByGameIdCommand, IEnumerable<CharacterDto>>
    {
        private readonly ICharacterApplication _characterApplication;
        private readonly IMapper _mapper;

        public GetCharactersByGameIdCommandHandler(ICharacterApplication characterApplication, IMapper mapper)
        {
            _characterApplication = characterApplication;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CharacterDto>> Handle(GetCharactersByGameIdCommand request, CancellationToken cancellationToken)
        {
            var characters = await _characterApplication.GetCharactersByGameIdAsync(request.GameId);
            var characterDtos = _mapper.Map<IEnumerable<CharacterDto>>(characters);
            return characterDtos;
        }
    }
}


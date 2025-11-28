using AutoMapper;
using Application.Dtos.Characters;
using Application.Features.Characters.Queries.Commands;
using MediatR;
using Application.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Characters.Queries.Handlers
{
    public class GetCharacterByIdCommandHandler : IRequestHandler<GetCharacterByIdCommand, CharacterDto?>
    {
        private readonly ICharacterApplication _characterApplication;
        private readonly IMapper _mapper;


        public GetCharacterByIdCommandHandler(ICharacterApplication characterApplication, IMapper mapper)
        {
            _characterApplication = characterApplication;
            _mapper = mapper;
        }

        public async Task<CharacterDto?> Handle(GetCharacterByIdCommand request, CancellationToken cancellationToken)
        {
            var character = await _characterApplication.GetCharacterByIdAsync(request.CharacterId);
            var characterDto = _mapper.Map<CharacterDto>(character);
            return characterDto;
        }
    }
}

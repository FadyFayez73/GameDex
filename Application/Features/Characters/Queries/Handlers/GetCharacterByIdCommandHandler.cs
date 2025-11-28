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
        private readonly ICharacterServices _characterServices;
        private readonly IMapper _mapper;


        public GetCharacterByIdCommandHandler(ICharacterServices characterServices, IMapper mapper)
        {
            _characterServices = characterServices;
            _mapper = mapper;
        }

        public async Task<CharacterDto?> Handle(GetCharacterByIdCommand request, CancellationToken cancellationToken)
        {
            var character = await _characterServices.GetCharacterByIdAsync(request.CharacterId);
            var characterDto = _mapper.Map<CharacterDto>(character);
            return characterDto;
        }
    }
}

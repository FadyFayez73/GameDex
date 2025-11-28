using AutoMapper;
using Application.Features.Characters.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Characters.Queries.Handlers
{
    public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, (bool, Guid)>
    {
        private readonly ICharacterServices _characterServices;
        private readonly IMapper _mapper;

        public CreateCharacterCommandHandler(ICharacterServices characterServices, IMapper mapper)
        {
            _characterServices = characterServices;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            var characterDomainModel = _mapper.Map<Character>(request);
            
            if (characterDomainModel == null)
                throw new ArgumentNullException(nameof(characterDomainModel), "Character domain model cannot be null");

            var result = await _characterServices.AddAsync(characterDomainModel);
            return result;
        }
    }
}


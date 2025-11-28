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
    public class UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand, bool>
    {
        private readonly ICharacterApplication _characterApplication;
        private readonly IMapper _mapper;

        public UpdateCharacterCommandHandler(ICharacterApplication characterApplication, IMapper mapper)
        {
            _characterApplication = characterApplication;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
        {
            var characterDomainModel = _mapper.Map<Character>(request);

            if (characterDomainModel == null)
                throw new ArgumentNullException(nameof(characterDomainModel), "Cannot convert from \"UpdateCharacterCommand\" to \"Character Domain Model\"!");

            var result = await _characterApplication.UpdateAsync(characterDomainModel);
            return result;
        }
    }
}


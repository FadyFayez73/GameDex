using AutoMapper;
using Core.Features.Platforms.Queries.Commands;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Platforms.Queries.Handlers
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, (bool, Guid)>
    {
        private readonly IPlatformServices _platformServices;
        private readonly IMapper _mapper;

        public CreatePlatformCommandHandler(IPlatformServices platformServices, IMapper mapper)
        {
            _platformServices = platformServices;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = _mapper.Map<Platform>(request);
            if (platform == null)
                throw new ArgumentNullException(nameof(platform), "Platform domain model cannot be null");

            var result = await _platformServices.AddAsync(platform);
            return result;
        }
    }
}
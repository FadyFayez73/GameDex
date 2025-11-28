using AutoMapper;
using Application.Features.Platforms.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Platforms.Queries.Handlers
{
    public class UpdatePlatformCommandHandler : IRequestHandler<UpdatePlatformCommand, bool>
    {
        private readonly IPlatformServices _platformServices;
        private readonly IMapper _mapper;

        public UpdatePlatformCommandHandler(IPlatformServices platformServices, IMapper mapper)
        {
            _platformServices = platformServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = _mapper.Map<Platform>(request);
            if (platform == null)
                throw new ArgumentNullException(nameof(platform), "Platform domain model cannot be null");

            var result = await _platformServices.UpdateAsync(platform);
            return result;
        }
    }
}
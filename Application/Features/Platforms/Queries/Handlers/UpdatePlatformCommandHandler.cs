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
        private readonly IPlatformApplication _platformApplication;
        private readonly IMapper _mapper;

        public UpdatePlatformCommandHandler(IPlatformApplication platformApplication, IMapper mapper)
        {
            _platformApplication = platformApplication;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = _mapper.Map<Platform>(request);
            if (platform == null)
                throw new ArgumentNullException(nameof(platform), "Platform domain model cannot be null");

            var result = await _platformApplication.UpdateAsync(platform);
            return result;
        }
    }
}
using AutoMapper;
using Application.Dtos.Platforms;
using Application.Features.Platforms.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Platforms.Queries.Handlers
{
    public class GetPlatformByIdCommandHandler : IRequestHandler<GetPlatformByIdCommand, PlatformDto?>
    {
        private readonly IPlatformApplication _platformApplication;
        private readonly IMapper _mapper;

        public GetPlatformByIdCommandHandler(IPlatformApplication platformApplication, IMapper mapper)
        {
            _platformApplication = platformApplication;
            _mapper = mapper;
        }

        public async Task<PlatformDto?> Handle(GetPlatformByIdCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.PlatformId == Guid.Empty)
                throw new ArgumentException("Invalid platform id.", nameof(request));

            var platform = await _platformApplication.GetPlatformByIdAsync(request.PlatformId);
            if (platform == null) return null;

            var dto = _mapper.Map<PlatformDto>(platform);

            return dto;
        }
    }
}
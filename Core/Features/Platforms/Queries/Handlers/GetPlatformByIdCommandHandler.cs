using AutoMapper;
using Core.Dtos.Platforms;
using Core.Features.Platforms.Queries.Commands;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Platforms.Queries.Handlers
{
    public class GetPlatformByIdCommandHandler : IRequestHandler<GetPlatformByIdCommand, PlatformDto?>
    {
        private readonly IPlatformServices _platformServices;
        private readonly IMapper _mapper;

        public GetPlatformByIdCommandHandler(IPlatformServices platformServices, IMapper mapper)
        {
            _platformServices = platformServices;
            _mapper = mapper;
        }

        public async Task<PlatformDto?> Handle(GetPlatformByIdCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.PlatformId == Guid.Empty)
                throw new ArgumentException("Invalid platform id.", nameof(request));

            var platform = await _platformServices.GetPlatformByIdAsync(request.PlatformId);
            if (platform == null) return null;

            var dto = _mapper.Map<PlatformDto>(platform);

            return dto;
        }
    }
}
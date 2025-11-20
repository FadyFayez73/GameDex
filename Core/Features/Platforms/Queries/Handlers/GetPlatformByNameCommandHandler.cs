using AutoMapper;
using Core.Dtos.Platforms;
using Core.Features.Platforms.Queries.Commands;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Platforms.Queries.Handlers
{
    public class GetPlatformByNameCommandHandler : IRequestHandler<GetPlatformByNameCommand, PlatformDto?>
    {
        private readonly IPlatformServices _platformServices;
        private readonly IMapper _mapper;

        public GetPlatformByNameCommandHandler(IPlatformServices platformServices, IMapper mapper)
        {
            _platformServices = platformServices;
            _mapper = mapper;
        }

        public async Task<PlatformDto?> Handle(GetPlatformByNameCommand request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Invalid platform name.", nameof(request));

            var platform = await _platformServices.GetPlatformByNameAsync(request.Name);
            if (platform == null) return null;

            var dto = _mapper.Map<PlatformDto>(platform);

            return dto;
        }
    }
}
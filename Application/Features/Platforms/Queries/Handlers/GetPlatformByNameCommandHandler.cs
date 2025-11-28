using AutoMapper;
using Application.Dtos.Platforms;
using Application.Features.Platforms.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Platforms.Queries.Handlers
{
    public class GetPlatformByNameCommandHandler : IRequestHandler<GetPlatformByNameCommand, PlatformDto?>
    {
        private readonly IPlatformApplication _platformApplication;
        private readonly IMapper _mapper;

        public GetPlatformByNameCommandHandler(IPlatformApplication platformApplication, IMapper mapper)
        {
            _platformApplication = platformApplication;
            _mapper = mapper;
        }

        public async Task<PlatformDto?> Handle(GetPlatformByNameCommand request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Invalid platform name.", nameof(request));

            var platform = await _platformApplication.GetPlatformByNameAsync(request.Name);
            if (platform == null) return null;

            var dto = _mapper.Map<PlatformDto>(platform);

            return dto;
        }
    }
}
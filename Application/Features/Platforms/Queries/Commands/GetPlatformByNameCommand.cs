using MediatR;
using Domain.Entities;
using Application.Dtos.Platforms;

namespace Application.Features.Platforms.Queries.Commands
{
    public class GetPlatformByNameCommand : IRequest<PlatformDto?>
    {
        public string Name { get; set; }

        public GetPlatformByNameCommand(string name)
        {
            Name = name;
        }
    }
}
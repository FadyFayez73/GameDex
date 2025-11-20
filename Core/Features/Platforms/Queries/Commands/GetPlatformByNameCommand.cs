using MediatR;
using Domain.Entities;
using Core.Dtos.Platforms;

namespace Core.Features.Platforms.Queries.Commands
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
using MediatR;
using System;

namespace Application.Features.Platforms.Queries.Commands
{
    public class UpdatePlatformCommand : IRequest<bool>
    {
        public Guid PlatformId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
using MediatR;
using System;

namespace Application.Features.Platforms.Queries.Commands
{
    public class CreatePlatformCommand : IRequest<(bool, Guid)>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
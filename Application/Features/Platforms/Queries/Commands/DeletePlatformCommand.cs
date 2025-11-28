using MediatR;
using System;

namespace Application.Features.Platforms.Queries.Commands
{
    public class DeletePlatformCommand : IRequest<bool>
    {
        public Guid PlatformId { get; set; }
    }
}
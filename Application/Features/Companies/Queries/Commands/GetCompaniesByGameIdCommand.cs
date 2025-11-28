using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Features.Companies.Queries.Commands
{
    public class GetCompaniesByGameIdCommand : IRequest<IEnumerable<Company>>
    {
        public Guid GameId { get; set; }

        public GetCompaniesByGameIdCommand(Guid gameId)
        {
            GameId = gameId;
        }
    }
}
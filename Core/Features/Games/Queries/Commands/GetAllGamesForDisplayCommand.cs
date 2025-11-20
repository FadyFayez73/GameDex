using Core.Dtos.Games;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Games.Queries.Commands
{
    public class GetAllGamesForDisplayCommand : IRequest<IEnumerable<GameForDisplayDto>>
    {

    }
}

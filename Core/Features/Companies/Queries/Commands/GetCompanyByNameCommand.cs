using MediatR;
using Domain.Entities;
using System;

namespace Core.Features.Companies.Queries.Commands
{
    public class GetCompanyByNameCommand : IRequest<Company?>
    {
        public string Name { get; set; }

        public GetCompanyByNameCommand(string name)
        {
            Name = name;
        }
    }
}
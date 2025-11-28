using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.Commands
{
    public class DeleteCompanyCommand : IRequest<bool>
    {
        public Guid CompanyId { get; set; }
    }
}

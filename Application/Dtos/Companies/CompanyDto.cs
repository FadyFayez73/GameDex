using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Companies
{
    public struct CompanyDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum CompanyRole
    {
        Developer,
        Publisher,
        Other
    }

    public class CompanyGame
    {
        public Guid GameID { get; set; }
        public Game Game { get; set; }

        public Guid CompanyID { get; set; }
        public Company Company { get; set; }

        public CompanyRole Role { get; set; }
    }
}

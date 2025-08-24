using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Company
    {
        // Property
        public Guid CompanyID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        // Game Entity Relation Many to Many
        public ICollection<CompanyGame> CompanyGames { get; set; }

    }
}

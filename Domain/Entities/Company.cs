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
        public CompanyTypeEnum CompanyType { get; set; }


        // Game Entity Relation Many to Many
        public ICollection<Game>? Games { get; set; }

        public enum CompanyTypeEnum
        {
            Developer,
            Publisher
        }
    }
}

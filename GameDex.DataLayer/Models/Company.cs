using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.DataLayer.Models
{
    public class Company
    {
        // Property
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CompanyType CompanyType { get; set; }


        // Game Entity Relation Many to Many
        public ICollection<Game>? Games { get; set; }
    }

    public enum CompanyType
    {
        Developer,
        Publisher
    }
}

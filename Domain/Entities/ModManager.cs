using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ModManager
    {
        // Proprty
        public Guid ModManagerID { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }

        // Game Entity Relation Many to Many
        public ICollection<Game>? Games { get; set; }
    }
}

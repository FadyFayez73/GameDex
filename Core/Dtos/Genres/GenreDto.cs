using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Genres
{
    public struct GenreDto
    {
        public Guid GenreID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

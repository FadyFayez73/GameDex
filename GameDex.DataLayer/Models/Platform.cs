﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.DataLayer.Models
{
    public class Platform
    {
        // Property
        public int PlatformID { get; set; }
        public string Name { get; set; }


        // Game Entity Relation Many to Many
        public ICollection<Game>? Games { get; set; }

    }
}

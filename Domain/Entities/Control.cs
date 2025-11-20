using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Control
    {
        //Property
        public Guid ControlID { get; set; }
        public string ControlType { get; set; }
        public string Action { get; set; }
        public string Key { get; set; }

        //Game Entity Relation Many to One
        public Guid GameID { get; set; }
        public Game? Game { get; set; }
    }
}

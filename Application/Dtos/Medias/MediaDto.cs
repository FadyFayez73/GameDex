using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Medias
{
    public struct MediaDto
    {
        public Guid MediaID { get; set; }
        public string MediaType { get; set; }
        public string MediaPath { get; set; }
    }
}

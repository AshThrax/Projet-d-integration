using Domain.Entity.TheatherEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTheather.DTO
{
    public class TicketDto
    {
        public string RepresentationTime { get; set; } = string.Empty;
        public int RepresentationId { get; set; }
        public string PieceTitre { get; set; } = string.Empty;
        public string SalleName { get; set; } = string.Empty;

    }
}

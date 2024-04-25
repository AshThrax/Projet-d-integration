using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.TheatherEntity
{
    public class Tickets : BaseEntity
    {
     
        public string? Representation { get; set; }
        public string? Piecetitle { get; set; }
        public string? SalleName { get; set; }
        public int CommandId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.TheatherEntity
{
    public class Catalogue: BaseEntity
    {
      
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Complexe? Complexe { get; set; } 
        public int ComplexeId { get; set; }
        public List<Piece>? Pieces { get; set; }
    }
}

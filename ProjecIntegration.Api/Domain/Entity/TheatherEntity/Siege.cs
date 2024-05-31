using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.TheatherEntity
{
    public class Siege : BaseEntity
    {
        public string Name {get; set;}= string .Empty;
        public int SalleId { get; set;}
        public SalleDeTheatre SalleDeTheatre { get; set;}

    }
}

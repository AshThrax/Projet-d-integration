using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.TheatherEntity
{
    public class SiegeCommand : BaseEntity
    {
        public int  SiegeId { get; set; }   
        public Siege Siege { get; set; }
        public int CommandId { get; set; }
        public Command Command { get; set; }
    }
}

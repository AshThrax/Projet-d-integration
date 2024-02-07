using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Models.Entity
{
    public class Tickets : BaseEntity
    {
        public string? Titre { get; set; }
        public string? Representation { get; set; }
        public string? Piecetitle { get; set;}
        public string? SalleName { get; set; }
        public int CommandId { get; set; }
        public Command Command { get; set; }
    }
}

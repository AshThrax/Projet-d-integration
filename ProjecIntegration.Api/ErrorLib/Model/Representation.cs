using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Representation :BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public SalleDeTheatre SalleDeTheatre { get; set; }
        public int IdSalledeTheatre { get; set; }
    }
}

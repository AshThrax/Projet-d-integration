using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class SalleDeTheatre:BaseEntity
    {
      
        public string Name { get; set; }

        public int PlaceMax { get; set; }
        
        public int PlaceCurrent { get; set; }
    }
}

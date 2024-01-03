using ProjecIntegration.Api.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecIntegration
{
    public class SalleDeTheatre:BaseEntity
    {
      
        public string Name { get; set; }

        public int PlaceMax { get; set; }
        
        public int PlaceCurrent { get; set; }
    }
}

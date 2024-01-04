using ProjecIntegration.Api.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecIntegration
{
    public class Complexe :BaseEntity
    {
       
        public string Name { get; set; }
        public string Description { get; set; }

        public List<SalleDeTheatre> SalleDeTheatres { get; set; }
        public List<Catalogue> Catalogues { get; set; }

    }
}

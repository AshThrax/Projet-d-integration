using ProjecIntegration.Api.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace ProjecIntegration
{
    public class Catalogue:BaseEntity
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Representation> Representations { get; set; }
        public Complexe Complexe { get; set; }
        public int ComplexeId { get; set; }
        public DateTime DebutCatalogue { get; set; }

        public DateTime FinCatalogue { get; set; }
    }
}

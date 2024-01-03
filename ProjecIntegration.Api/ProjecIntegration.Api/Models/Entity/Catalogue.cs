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
        public DateTime debutCatalogue { get; set; }

        public DateTime finCatalogue { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Catalogue:BaseEntity
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime debutCatalogue { get; set; }

        public DateTime finCatalogue { get; set; }
    }
}

using ProjecIntegration.Api.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecIntegration
{
    public class Entreprise :BaseEntity
    {
        public string Nom { get; set; }
        public string Adress { get; set; }
        public List <Complexe> Complexes { get; set; }
    }
}

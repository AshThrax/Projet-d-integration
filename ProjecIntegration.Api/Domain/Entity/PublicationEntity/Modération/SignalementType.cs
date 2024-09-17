using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.PublicationEntity.Modération
{
    public class SignalementType :BaseEntity
    {
        public string Titre { get; set; }= string.Empty;
        public string Motif { get; set;} = string.Empty;
        public bool IsPertinent { get; set; }
    }
}

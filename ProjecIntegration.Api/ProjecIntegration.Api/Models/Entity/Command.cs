using ProjecIntegration.Api.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecIntegration
{
    public class Command :BaseEntity
    {
        public string Name { get; set; }
        public IList<Ticket> Tickets { get; set; }   
        public User User { get; set; }
        public int IdUser { get; set; } 

    }
}

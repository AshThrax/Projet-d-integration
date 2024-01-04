using ProjecIntegration.Api.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecIntegration
{
    public class Ticket:BaseEntity
    {
       
        public string Name { get; set; }
        public Representation Representation { get; set; }
        public int IdRepresnentation { get; set; }
        public Command Command { get; set; }
        public int CommandId { get; set; }
        public Prix Prix { get; set; }
        public int IdPrix { get; set; }
    }
}

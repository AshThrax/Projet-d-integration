using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class User:BaseEntity
    {
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string Email { get; set; }
    }
}

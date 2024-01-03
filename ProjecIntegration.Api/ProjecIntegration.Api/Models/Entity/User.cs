using ProjecIntegration.Api.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecIntegration
{
    public class User:BaseEntity
    {
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string Email { get; set; }
    }
}

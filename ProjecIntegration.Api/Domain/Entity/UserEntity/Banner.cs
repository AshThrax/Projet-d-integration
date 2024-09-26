using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.UserEntity
{
    public class Banner:BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public string ImageRessource { get; set; } =string.Empty; 
    }
}

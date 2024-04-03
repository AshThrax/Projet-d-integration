using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.publicationEntity
{
    public class Post :BaseEntity
    {
        public string Content { get; set; }
        public User User { get; set; }
        public int USerID { get; set; }
    }
}

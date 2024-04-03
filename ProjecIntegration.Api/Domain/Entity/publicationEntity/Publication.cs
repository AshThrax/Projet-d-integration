using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.publicationEntity
{
    public class Publication:BaseEntity
    {
        public string Title { get; set; }
        public string Review { get; set; }
        public int USerId { get; set; }
        public User User { get; set; }

        public ICollection<Post> Publications { get; set; } = new List<Post>();
    }
}

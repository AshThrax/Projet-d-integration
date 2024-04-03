using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.publicationEntity
{
    public class Publication: BaseMongoEntity
    {
        public string Title { get; set; }
        public string Review { get; set; }
        public string  UserId { get; set; }
       

        public ICollection<string> Publications { get; set; } = new List<string>();
    }
}

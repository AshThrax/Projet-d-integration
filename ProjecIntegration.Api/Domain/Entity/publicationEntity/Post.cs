using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.publicationEntity
{
    public class Post : BaseMongoEntity
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public ICollection<RePost> Repost { get; set; } = new List<RePost>();
    }
}

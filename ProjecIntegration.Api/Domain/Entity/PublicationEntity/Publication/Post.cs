using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.publicationEntity
{
    public class Post : BaseEntity
    {
      
        public string? Content { get; set; }
        public string? UserId { get; set; }
        public string? PublicationId { get; set; }
        public int LikeNumber { get; set; }
        public ICollection<Repost> Repost { get; set; } = new List<Repost>();
    }
}

using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.publicationEntity
{
    public class Repost:BaseEntity
    {
        
        public string Content { get; set; } = string.Empty;
        public string UserId { get; set; } =string.Empty;
        public int LikeNumber { get; set; }
    }
}

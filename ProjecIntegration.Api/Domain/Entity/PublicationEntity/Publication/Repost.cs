using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.publicationEntity
{
    public class Repost:BaseMongoEntity
    {
        [BsonElement("Repost_Content")]
        public string Content { get; set; } = string.Empty;
        [BsonElement("Repost_UserId")]
        public string UserId { get; set; } =string.Empty;
        [BsonElement("Repost_LikeNumber")]
        public int LikeNumber { get; set; }
    }
}

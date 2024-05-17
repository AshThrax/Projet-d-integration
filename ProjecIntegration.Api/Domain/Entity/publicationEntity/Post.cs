using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.publicationEntity
{
    public class Post : BaseMongoEntity
    {
        [BsonElement("Post_Content")]
        public string? Content { get; set; }
        [BsonElement("Post_UserId")]
        public string? UserId { get; set; }
        [BsonElement("Post_PublicationId")]
        public string? PublicationId { get; set; }
        [BsonElement("Post_Repost")]
        public ICollection<Repost> Repost { get; set; } = new List<Repost>();
    }
}

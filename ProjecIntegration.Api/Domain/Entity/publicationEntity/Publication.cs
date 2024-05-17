using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.publicationEntity
{
    public class Publication: BaseMongoEntity
    {
        [BsonElement("Pub_Title")]
        public string Title { get; set; }
        [BsonElement("Pub_Review")]
        public string Review { get; set; }
        [BsonElement("Pub_UserId")]
        public string  UserId { get; set; }
        [BsonElement("Pub_Piece_Id")]
        public int PieceId { get; set; }
        [BsonElement("Pub_Post")]
        public ICollection<string> post { get; set; } = new List<string>();
    }
}

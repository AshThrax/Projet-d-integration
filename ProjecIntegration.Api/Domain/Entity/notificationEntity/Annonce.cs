using Domain.Enum;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.notificationEntity
{
    public class Annonce: BaseMongoEntity
    {
        [BsonElement("Ann_Title")]
        public string Title { get; set; } =string.Empty;
        [BsonElement("Ann_Description")]
        public string Description { get; set; } =string.Empty;
        [BsonElement("Ann_PieceId")]
        public int PieceId { get; set; }
        [BsonElement("Ann_Priority")]

        public EPrioirity Priority { get; set; }
      
    }
}

using Domain.Enum;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.notificationEntity
{
    public class Notification:BaseMongoEntity
    {
        [BsonElement("Notif_Title")]
        public string Title { get; set; } =string.Empty;
        [BsonElement("Notif_Message")]
        public string Message { get; set; } = string.Empty;
        [BsonElement("Notif_Priority")]
        public EPrioirity Prioirity { get; set; }
        [BsonElement("Notif_UserId")]
        public string UserId { get; set; } = string.Empty;
       

    }
}

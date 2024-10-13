using Domain.Enum;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.notificationEntity
{
    public class Annonce:BaseEntity
    {

        public string Title { get; set; } =string.Empty;
        public string Description { get; set; } =string.Empty;

        public int PieceId { get; set; }

        public EPrioirity Priority { get; set; }
      
    }
}

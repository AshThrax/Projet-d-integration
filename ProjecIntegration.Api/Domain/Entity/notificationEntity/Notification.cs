using Domain.Enum;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.notificationEntity
{
    public class Notification:BaseEntity
    {
      
        public string Title { get; set; } =string.Empty;
       
        public string Message { get; set; } = string.Empty;
  
        public EPrioirity Prioirity { get; set; }
       
        public string UserId { get; set; } = string.Empty;
       

    }
}

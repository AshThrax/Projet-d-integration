using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.notificationEntity
{
    public class Notification:BaseMongoEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public EPrioirity Prioirity { get; set; }
        public string UserId { get; set; }
        public DateTime CreateTime { get; set; }

    }
}

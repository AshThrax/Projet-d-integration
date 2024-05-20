using Domain.Enum;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAnnonce.DTO
{
    public class NotificationDto : BaseDto
    {

        public string Title { get; set; }
        public string Message { get; set; }
        public EPrioirity Prioirity { get; set; }
        public string UserId { get; set; }
    }
    public class UpdateNotificationDto : BaseDto
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public EPrioirity Prioirity { get; set; }
        public string UserId { get; set; }
    }
    public class AddNotificationDto
    {

        public string Title { get; set; }
        public string Message { get; set; }
        public EPrioirity Prioirity { get; set; }
        public string UserId { get; set; }
    }
}

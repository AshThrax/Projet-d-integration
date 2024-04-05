using Domain.Entity.notificationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.businessService
{
    public interface INotificationBl
    {
        Task CreateNotification(Notification notification);
        Task UpdateNotification(string  notificationId,Notification notification);
        Task DeleteNotification(string notificationId);
        Task<Notification> GetNotificationById(string id);
        Task<IEnumerable<Notification>> GetNotificationByUserId(string userId);
    }
}

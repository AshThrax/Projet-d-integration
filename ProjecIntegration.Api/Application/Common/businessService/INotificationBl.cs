using Application.DTO;
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
        Task CreateNotification(AddNotificationDto notification);
        Task UpdateNotification(string  notificationId,UpdateNotificationDto notification);
        Task DeleteNotification(string notificationId);
        Task<NotificationDto> GetNotificationById(string id);
        Task<IEnumerable<NotificationDto>> GetNotificationByUserId(string userId);
    }
}

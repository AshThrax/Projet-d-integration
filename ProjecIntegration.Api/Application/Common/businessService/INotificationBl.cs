using Application.DTO;
using Domain.DataType;
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
        void CreateNotification(AddNotificationDto notification);
        Task UpdateNotification(string  notificationId,UpdateNotificationDto updtNotification);
        Task DeleteNotification(string notificationId);
        Task<NotificationDto> GetNotificationById(string id);
        Task<Pagination<NotificationDto>> GetNotificationByUserId(string userId,int pageNumber);
    }
}

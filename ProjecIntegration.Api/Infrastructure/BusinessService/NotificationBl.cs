using Application.Common.businessService;
using Application.Common.Repository;
using Domain.Entity.notificationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BusinessService
{
    public class NotificationBl : INotificationBl
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationBl(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public Task CreateNotification(Notification notification)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNotification(string notificationId)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetNotificationById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notification>> GetNotificationByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNotification(string notificationId, Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}

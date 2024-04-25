using Domain.Entity.notificationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repository
{
    public interface INotificationRepository { 
        Task<IEnumerable<Notification>> GetAll(params Expression<Func<Notification, object>>[] includeProperties);
        Task<Notification> GetById(string id, params Expression<Func<Notification, object>>[] includeProperties);
        Task<IEnumerable<Notification>> GetAll();
        Task<Notification> GetById(string id);
        void Insert(Notification entity);
        void Update(string entityId, Notification entity);
        void Delete(string entityId);
    }
}

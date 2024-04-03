using Application.Common.Repository;
using Domain.Entity.notificationEntity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class NotificiationRepository : MongoRepository<Notification>, INotificationRepository
    {
        public NotificiationRepository(IMongoDatabase database, string collectionName) : base(database, collectionName)
        {
        }
    }
}

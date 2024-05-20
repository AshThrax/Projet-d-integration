using ApplicationAnnonce.Common.Repository;
using Domain.Entity.notificationEntity;
using InfrastructureAnnonce.Persistence;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureAnnonce.Repository
{
    public class NotificiationRepository : MongoRepository<Notification>, INotificationRepository
    {
        private readonly IMongoCollection<Notification> _notificationCollection;
        private readonly NotificationMongoContext _database;
        public NotificiationRepository(NotificationMongoContext database) : base(database)
        {
            _database = database;
            _notificationCollection = database.Dbset<Notification>();
        }

        public async Task<IEnumerable<Notification>> GetNotificationByUserId(string userId)
        {
            IEnumerable<Notification> listNotification = new List<Notification>();
            try
            {
                FilterDefinitionBuilder<Notification> Builder = Builders<Notification>
                                                                                        .Filter;
                FilterDefinition<Notification> filter = Builder.Eq(x => x.UserId, userId);

                listNotification = await _notificationCollection.Find(filter)
                                                     .ToListAsync();
            }
            catch (Exception)
            {
            }
            return listNotification;
        }
    }
}

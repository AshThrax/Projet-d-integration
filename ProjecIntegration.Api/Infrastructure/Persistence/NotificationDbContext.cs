using Domain.Entity.notificationEntity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence
{
    public class NotificationDbContext
    {
        private readonly IMongoDatabase _database;
        public NotificationDbContext(IOptions<NotificationStettings> settings)
        {
            var client= new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Notification> GetNotification() {
            return _database.GetCollection<Notification>("Notification");
        }
    }
}

using Domain.Entity.notificationEntity;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence
{
    public class NotificationMongoContext
    {
        private readonly IMongoDatabase _database;
        public NotificationMongoContext(IOptions<NotificationStettings> settings)
        {
           
                MongoClient client= new MongoClient(settings.Value.ConnectionString);
                _database = client.GetDatabase(settings.Value.DatabaseName);
           
        }
        public IMongoCollection<T> Dbset<T>()
        {
            return _database.GetCollection<T>(nameof(T));
        }
        public IMongoCollection<Notification> GetNotification() {
            return _database.GetCollection<Notification>("Notification");
        }
        public IMongoCollection<Annonce> GetAnnonce()
        {
            return _database.GetCollection<Annonce>("Annonce");
        }
    }
}

using Domain.Entity.notificationEntity;
using Domain.Entity.publicationEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.Persistence
{
    public class PublicationMongoContext 
    {
        private readonly IMongoDatabase _database;
        public PublicationMongoContext(IOptions<PublicationSetttings> settings)
        {
          
                MongoClient client = new MongoClient(settings.Value.ConnectionString);
                _database = client.GetDatabase(settings.Value.DatabaseName);

        }

        public IMongoCollection<T> DbSet<T>()
        {
            return _database.GetCollection<T>(nameof(T));   
        }
        public IMongoCollection<Publication> GetPublication()
        {
            return _database.GetCollection<Publication>("Publication");
        }
        public IMongoCollection<Post> GetPost()
        {
            return _database.GetCollection<Post>("Post");
        }
        public IMongoCollection<RePost> GetRePost()
        {
            return _database.GetCollection<RePost>("RePost");
        }
      
    }
}

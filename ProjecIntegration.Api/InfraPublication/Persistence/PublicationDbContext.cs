using Domain.Entity.notificationEntity;
using Domain.Entity.publicationEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.Persistence
{
    public class PublicationDbContext 
    {
        private readonly IMongoDatabase _database;
        public PublicationDbContext(IOptions<PublicationSetttings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Publication> GetPublication()
        {
            return _database.GetCollection<Publication>("Publication");
        }
        public IMongoCollection<RePost> GetRePost()
        {
            return _database.GetCollection<RePost>("RePost");
        }
      
    }
}

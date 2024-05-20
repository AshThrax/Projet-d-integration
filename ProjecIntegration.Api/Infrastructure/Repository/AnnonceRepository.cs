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
    public class AnnonceRepository : MongoRepository<Annonce>, IAnnonceRepository
    {
        private readonly IMongoCollection<Annonce> _annonceCollection;
        private readonly NotificationMongoContext _database;
        public AnnonceRepository(NotificationMongoContext database) : base(database)
        {
            _database = database;
            _annonceCollection = database.Dbset<Annonce>();
        }
    }
}

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
    public class AnnonceRepository : MongoRepository<Annonce>, IAnnonceRepository
    {
        public AnnonceRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}

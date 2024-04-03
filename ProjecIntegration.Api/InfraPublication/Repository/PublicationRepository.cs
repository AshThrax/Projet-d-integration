using ApplciationPublication.Common.Repository;
using Domain.Entity.publicationEntity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.Repository
{
    public class PublicationRepository : MongoRepository<Publication>, IPublicationRepository
    {
        public PublicationRepository(IMongoDatabase database, string collectionName) : base(database, collectionName)
        {
        }
    }
}

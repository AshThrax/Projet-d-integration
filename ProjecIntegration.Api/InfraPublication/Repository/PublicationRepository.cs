using ApplciationPublication.Common.Repository;
using Domain.Entity.publicationEntity;
using InfraPublication.Persistence;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.Repository
{
    public class PublicationRepository :  IPublicationRepository
    {
        private readonly IMongoCollection<Publication> _collection;
        public PublicationRepository(IMongoDatabase database) : base(database)
        {
            _collection= database.GetCollection<Publication>(nameof(Publication));
        }

        public async Task UpdatePublicationContent(string publicationid, string content)
        {
           var builder= Builders<Publication>.Filter.Eq(x =>x.Id, publicationid);
           var update = Builders<Publication>.Update.Set(x => x.Review, content);

            await _collection.UpdateOneAsync(builder, update);
        }
    }
}

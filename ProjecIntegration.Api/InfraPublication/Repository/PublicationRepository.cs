using ApplicationPublication.Common.Repository;
using Domain.Entity.notificationEntity;
using Domain.Entity.publicationEntity;
using InfraPublication.Persistence;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.Repository
{
    public class PublicationRepository : MongoRepository<Publication>, IPublicationRepository
    {
        private readonly IMongoCollection<Publication> _collection;
        public PublicationRepository(PublicationMongoContext database):base(database) 
        {
           _collection=database.DbSet<Publication>();   
        }

        public async Task<IEnumerable<Publication>> GetAllPublicationByPieceId(int PieceId)
        {
            FilterDefinitionBuilder<Publication> builder = Builders<Publication>.Filter;
            FilterDefinition<Publication> filter = builder.Eq(x=>x.PieceId,PieceId);

            return await _collection.Find(filter)
                                    .ToListAsync();
        }
    

        public async Task<IEnumerable<Publication>> GetAllPublicationByUserId(string userId)
        {
            FilterDefinitionBuilder<Publication> builder = Builders<Publication>.Filter;
            FilterDefinition<Publication> filter = builder.Eq(a =>a.UserId,userId);

            return await _collection.Find(filter)
                                    .ToListAsync();
        }

        public async Task UpdatePublicationContent(string publicationid, string Title, string content)
        {
           var builder= Builders<Publication>.Filter.Eq(x =>x.Id, publicationid);
           var update = Builders<Publication>.Update.Set(x => x.Review, content)
                                                    .Set(x => x.Title, Title)
                                                    .Set(x => x.UpdatedDate, DateTime.Now);

            await _collection.UpdateOneAsync(builder, update);
        }
    }
}

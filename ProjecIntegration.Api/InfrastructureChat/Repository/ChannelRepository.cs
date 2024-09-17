using ApplicationChat.Common.Repository;
using Domain.Entity.ChatEntity;
using InfrastructureChat.Persistence;
using MongoDB.Driver.Core.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureChat.Repository
{
    public class ChannelRepository : MongoRepository<Channel>, IChannelRepository
    {
        public ChannelRepository(ChatMongoContext database) : base(database)
        {
        }
    }
}

using ApplicationChat.Common.Repository;
using Domain.Entity.ChatEntity;
using InfrastructureChat.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureChat.Repository
{
    public class ChatMessageRepository : MongoRepository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(ChatMongoContext database) : base(database)
        {
        }
    }
}

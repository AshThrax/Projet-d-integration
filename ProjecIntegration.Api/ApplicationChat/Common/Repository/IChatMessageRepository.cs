using ApplicationChat.Common.Interface;
using Domain.Entity.ChatEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationChat.Common.Repository
{
    public interface IChatMessageRepository : IRepository<ChatMessage>
    {
    }
}

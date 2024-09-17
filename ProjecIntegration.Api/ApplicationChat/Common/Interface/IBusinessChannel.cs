using Domain.Entity.ChatEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationChat.Common.Interface
{
    public interface IBusinessChannel
    {
        Task AddMessage(string channelId);
        Task AddChannel(string userIdEmmetteur, string userIdRecepteur);
        Task RemoveMessage(string channelId,string chatMessageId);
        Task RemoveChannel(string channelId, string chatMessageId);
        Task<IEnumerable<Channel>> GetAllUserChannel(string userId);
        Task<IEnumerable<ChatMessage>> GetAllMessage(string ChannelId);
        Task<Channel> GetChannelId(string channelId);
        Task UpdateMessage(string channelId, ChatMessage message);
        Task<bool> DoIHaveAChannel(string userIdEmmetteur,string userIdRecepteur);
    }
}

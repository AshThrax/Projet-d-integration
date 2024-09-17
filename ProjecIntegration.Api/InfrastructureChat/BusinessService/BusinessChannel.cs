using ApplicationChat.Common.Interface;
using Domain.Entity.ChatEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureChat.BusinessService
{
    public class BusinessChannel : IBusinessChannel
    {
        public Task AddChannel(string userIdrecepteur, string USerIdEmmetteur)
        {
            throw new NotImplementedException();
        }

        public Task AddMessage(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoIHaveAChannel(string userIdEmmetteur, string userIdRecepteur)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChatMessage>> GetAllMessage(string ChannelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Channel>> GetAllUserChannel(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Channel> GetChannelId(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveChannel(string channelId, string chatMessageId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMessage(string channelId, string chatMessageId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMessage(string channelId, ChatMessage message)
        {
            throw new NotImplementedException();
        }
    }
}

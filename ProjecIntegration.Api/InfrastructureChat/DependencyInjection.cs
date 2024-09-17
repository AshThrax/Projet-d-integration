using ApplicationChat.Common.Repository;
using InfrastructureChat.Persistence;
using InfrastructureChat.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureChat
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddChatInfrastructure(this IServiceCollection service,IConfiguration configure)
        {
            service.AddScoped<IChatMessageRepository,ChatMessageRepository>();
            service.AddScoped<IChannelRepository, ChannelRepository>();
            //-----------
            

            service.Configure<ChatSettings>(options =>
            {
                options.ConnectionString = configure.GetConnectionString("MongoDb");
                options.DatabaseName = "Chat";
            });
            return service;
        }
    }
}

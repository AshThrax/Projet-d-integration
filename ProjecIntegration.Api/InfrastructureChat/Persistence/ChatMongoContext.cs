using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureChat.Persistence
{
    public class ChatMongoContext
    {
        private readonly IMongoDatabase _database;
        public ChatMongoContext(IOptions<ChatSettings> settings)
        {

            MongoClient client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);

        }
        public IMongoCollection<T> Dbset<T>()
        {
            return _database.GetCollection<T>(typeof(T).ToString());
        }
    }
}

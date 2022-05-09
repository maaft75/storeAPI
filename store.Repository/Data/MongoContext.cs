using MongoDB.Driver;
using store.Domain.Config;
using Microsoft.Extensions.Options;
using store.Domain.Models.v2;

namespace store.Repository.Data
{
    public class MongoContext
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public MongoContext(IOptions<MongoDbSettings> MongoDbSettings)
        {
            _mongoClient = new MongoClient(MongoDbSettings.Value.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(MongoDbSettings.Value.Database);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _mongoDatabase.GetCollection<T>(name);
        }
    }
}
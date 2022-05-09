using store.Repository.Data;
using store.Domain.Models.v2;

namespace store.Repository.Repository.v2
{
    public class UserRepository : GenericMongoDbRepository<User>
    {
        public UserRepository(MongoContext mongoContext, string name = "User") : base(name, mongoContext)
        {
        }
    }
}
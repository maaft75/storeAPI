using System.Transactions;
using store.Domain.Models;

namespace store.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Save();
        IUserRepository userRepo{ get; }
        IStoreRepository storeRepo{ get; }
        //MongoDbRepository<User> mongoUserRepo{ get; }
    }
}
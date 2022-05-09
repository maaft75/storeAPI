using store.Domain.Models;

namespace store.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Save();
        IUserRepository userRepo{ get; }
        //MongoDbRepository<User> mongoUserRepo{ get; }
    }
}
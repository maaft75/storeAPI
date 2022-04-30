using store.Domain.Models;
using store.Repository.Data;
using store.Domain.Interfaces;

namespace store.Repository.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(StoreContext context) : base(context)
        {
            
        }
    }
}
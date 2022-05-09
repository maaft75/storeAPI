using store.Repository.Data;
using store.Domain.Models.v1;
using store.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace store.Repository.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(StoreContext context) : base(context)
        {
            
        }

        public Task<bool> CheckIfEmailExists(string emailAddress)
        {
            return _context.TBL_USERS.AnyAsync(x => x.Email_Address == emailAddress);
        }
    }
}
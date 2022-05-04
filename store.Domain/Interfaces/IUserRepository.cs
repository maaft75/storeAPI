using store.Domain.Models;

namespace store.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> CheckIfEmailExists(string emailAddress);
    }
}
using store.Domain.Models.v1;

namespace store.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> CheckIfEmailExists(string emailAddress);
    }
}
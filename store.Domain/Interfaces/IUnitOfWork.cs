namespace store.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Save();
        IUserRepository userRepo{ get; }
    }
}
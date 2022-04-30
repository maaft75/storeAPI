namespace store.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        IUserRepository userRepo{ get; }
    }
}
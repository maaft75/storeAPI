using store.Repository.Data;
using store.Domain.Interfaces;
using store.Repository.Repository;

namespace store.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private StoreContext _context;
        private UserRepository _userRepository;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }

        public IUserRepository userRepo
        {
            get
            {
                if(_userRepository == null) _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public void Save(){
            _context.SaveChangesAsync();
        }
    }
}
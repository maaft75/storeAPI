using store.Repository.Data;
using store.Domain.Interfaces;
using store.Repository.Repository;
using store.Repository.Repository.v1;
using store.Domain.Models.v1;

namespace store.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private StoreContext _context;
        private UserRepository _userRepository;
        private StoreRepository _storeRepository;

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

        public IStoreRepository storeRepo{
            get
            {
                if(_storeRepository == null) _storeRepository = new StoreRepository(_context);
                return _storeRepository;
            }
        }

        public async Task<bool> Save(){
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
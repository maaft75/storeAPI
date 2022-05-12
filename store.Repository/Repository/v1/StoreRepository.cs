using store.Repository.Data;
using store.Domain.Models.v1;
using store.Domain.Interfaces;
namespace store.Repository.Repository.v1
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        public StoreRepository(StoreContext context) : base(context)
        {
        }
    }
}
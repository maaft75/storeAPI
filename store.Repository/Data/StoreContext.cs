using store.Domain.Models.v1;
using Microsoft.EntityFrameworkCore;

namespace store.Repository.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options){}

        public DbSet<User> TBL_USERS{get; set;}
    }
}
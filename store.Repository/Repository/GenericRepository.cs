using store.Repository.Data;
using store.Domain.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace store.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<List<T>> FindByAll(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }
    }
}
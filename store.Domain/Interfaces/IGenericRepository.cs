using System.Linq.Expressions;

namespace store.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<List<T>> FindByAll();
        Task<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
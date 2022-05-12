using store.Repository.Data;
using store.Domain.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace store.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly StoreContext _context;

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

        public async Task<List<T>> FindByAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}

        //WITHOUT UNIT OF WORK
        //IGENERIC REPO
        //GENERIC REPO
        //USER REPO CAN USE THIS NORMALLY.

        //WITH UNIT OF WORK
        //IGENERIC REPO
        //GENERIC REPO
        //IUSER REPO THAT THAT CAN CONTAINS IT'S OWN CONTRACTS AND THE IGENERIC REPO CONTRACTS(IT INHERITS IT)
            //THE MAJOR REASON IUSER INHERITS IGENERIC IS BECAUSE IT'LL BE REGISTERED WITHIN THE UNIT OF WORK CLASS.
        //USER REPO THAT INHERITS GENERIC REPO AND IUSER REPO. WHY ?
            //Although IUSER REPO HOLDS BOTH THE GENERIC CONTRACTS AND NON GENERIC CONTRACTS, GENERIC REPO HOLDS
            //THE IMPLEMEnTATION
        //IUNIT OF WORK CONTAINS A SAVE FUNCTION AND MODEL BASED INTERFACE(S)

        //UNIT OF WORK
using MongoDB.Driver;
using store.Domain.Config;
using store.Domain.Interfaces;
using Microsoft.Extensions.Options;
using store.Repository.Data;

namespace store.Repository.Repository
{
    public class GenericMongoDbRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string _name;
        private readonly MongoContext _mongoContext;

        public GenericMongoDbRepository(string name,  MongoContext  mongoContext)
        {
            _name = name;
            _mongoContext = mongoContext;
        }

        public async Task Create(T entity)
        {
            await _mongoContext.GetCollection<T>(_name).InsertOneAsync(entity);
            //await _TCollection.InsertOneAsync(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> FindByAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
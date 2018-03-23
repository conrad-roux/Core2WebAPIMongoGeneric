using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core2WebAPIMongoGeneric.Repo
{
    public class MongoRepo<T>
    {
        protected IMongoCollection<T> _collection;
        private MongoConnect _mongo = new MongoConnect();

        public MongoRepo(string collection)
        {
            _collection = _mongo.Database.GetCollection<T>(collection);
        }

        public async Task<IList<T>> Find(Expression<Func<T, bool>> query)
        {
            return await _collection.Find<T>(query).ToListAsync();
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> query)
        {
            var deleteOne = await _collection.DeleteOneAsync<T>(query);
            return true;
        }

        public async Task<bool> Add(T model)
        {
            bool value = false;
            try { await _collection.InsertOneAsync(model); value = true; }
            catch (Exception ex) { value = false; string e = ex.Message; }

            return value;
        }

        public async Task<bool> Update(Expression<Func<T, bool>> query, UpdateDefinition<T> builders)
        {
            bool value = false;
            try { var updateOne = await _collection.UpdateOneAsync<T>(query, builders); }
            catch (Exception ex) { value = false; string e = ex.Message; }

            return value;
        }

        public async Task<long> Count(Expression<Func<T, bool>> query)
        {
            return await _collection.CountAsync(query);
        }
    }
}

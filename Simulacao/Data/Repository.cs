using Simulacao.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simulacao.Data
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        readonly SQLiteAsyncConnection _db;

        public Repository()
        {
            this._db = DBHelper.DBConnection;
        }              

        public async Task<bool> InsertAllAsync(List<T> list)
        {
           return (await _db.InsertAllAsync(list) > 0);
        }

        public async Task DeleteAllAsync()
        {
            await _db.DeleteAllAsync<T>();
        }               

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _db.Table<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _db.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(int id) => await _db.FindAsync<T>(id);

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate) => await _db.FindAsync<T>(predicate);

        public async Task<int> InsertAsync(T entity) => await _db.InsertAsync(entity);

        public async Task<int> UpdateAsync(T entity) => await _db.UpdateAsync(entity);

        public async Task<int> DeleteAsync(T entity) => await _db.DeleteAsync(entity);

        public AsyncTableQuery<T> AsQueryable() => _db.Table<T>();

    }
}

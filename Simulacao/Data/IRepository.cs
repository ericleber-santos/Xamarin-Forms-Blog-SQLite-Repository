using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simulacao.Data
{
    public interface IRepository<T> where T : class, new()
    {       
        Task DeleteAllAsync();
        Task<bool> InsertAllAsync(List<T> list);
        Task<IEnumerable<T>> GetAsync();        
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAsync<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        AsyncTableQuery<T> AsQueryable();
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}

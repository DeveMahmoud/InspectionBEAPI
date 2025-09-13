using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{

    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task DeleteAsync(T entity);      

        Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
        IQueryable<T> GetQueryable();  

    }
}

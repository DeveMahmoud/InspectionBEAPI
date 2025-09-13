using ApplicationLayer.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _db;
    public GenericRepository(AppDbContext db) { _db = db; }
    public async Task AddAsync(T entity) => await _db.Set<T>().AddAsync(entity);
    public async Task<T?> GetByIdAsync(int id) => await _db.Set<T>().FindAsync(id);
    public void Remove(T entity) => _db.Set<T>().Remove(entity);
    public void Update(T entity) => _db.Set<T>().Update(entity);
    public async Task<IReadOnlyList<T>> ListAsync() => await _db.Set<T>().ToListAsync();
    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _db.Set<T>().Where(predicate).ToListAsync();

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _db.Set<T>().Update(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(T entity)
    {
        _db.Set<T>().Remove(entity);
        await Task.CompletedTask;
    }

    

    public IQueryable<T> GetQueryable()
    {
        return _db.Set<T>().AsQueryable();
    }
}

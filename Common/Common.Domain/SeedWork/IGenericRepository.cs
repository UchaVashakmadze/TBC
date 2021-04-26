using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Domain.SeedWork
{
    public interface IGenericRepository<T> : IRepository<T> where T : class
    {
        void Add(T entity);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        bool Any(Expression<Func<T, bool>> where);
        Task<bool> AnyAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);
        int Count(Expression<Func<T, bool>> where);
        Task<int> CountAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);
        Task<int> CountAsync(IQueryable<T> data, CancellationToken cancellationToken = default);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> where);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);
        Task<List<T>> ToListAsync(IQueryable<T> data, CancellationToken cancellationToken = default);
        T GetSingle(Expression<Func<T, bool>> where);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);
        void Update(T entity);
    }
}

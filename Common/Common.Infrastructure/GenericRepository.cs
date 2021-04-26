using Common.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public class GenericRepository<T, TK> : IGenericRepository<T> where T : class
            where TK : DbContext 
    {
        public readonly TK Context;

        public GenericRepository(TK context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Add(entity);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Context.AddAsync(entity, cancellationToken);
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return Context.Set<T>().AsNoTracking().Any(where);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().AnyAsync(where, cancellationToken);
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return Context.Set<T>().AsNoTracking().Count(where);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().CountAsync(where, cancellationToken);
        }

        public async Task<int> CountAsync(IQueryable<T> data, CancellationToken cancellationToken = default)
        {
            return await data.AsNoTracking().CountAsync(cancellationToken);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> @where)
        {
            return Context.Set<T>().AsNoTracking().Where(where);
        }

        public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> @where, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().Where(where).ToListAsync(cancellationToken);
        }

        public virtual async Task<List<T>> ToListAsync(IQueryable<T> data, CancellationToken cancellationToken = default)
        {
            return await data.AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> @where)
        {
            return Context.Set<T>().AsNoTracking().FirstOrDefault(where);
        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> @where, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(where, cancellationToken);
        }

        public virtual void Update(T entity)
        {
            Context.Update(entity);
        }

    }
}

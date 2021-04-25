using Delof.Data.Filter;
using Delof.Ddd.Domain.Entities;
using Delof.Ddd.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Delof.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : BasicRepositoryBase<TEntity>, IRepository<TEntity>
          where TEntity : class, IAggregateRoot
    {
        public IDataFilter DataFilter => LazyServiceProvider.LazyGetRequiredService<IDataFilter>();

        protected IEnumerable<IDataFilterProcesser> DataFilterProcessers => LazyServiceProvider.LazyGetServices<IDataFilterProcesser>();

        public abstract Task<IQueryable<TEntity>> GetQueryableAsync();

        public abstract Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(predicate, cancellationToken);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity));
            }

            return entity;
        }

        public abstract Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        protected virtual TQueryable ApplyDataFilters<TQueryable>(TQueryable query)
            where TQueryable : IQueryable<TEntity>
        {
            if (!DataFilterProcessers.IsNullOrEmpty())
            {
                foreach (var process in DataFilterProcessers)
                {
                    query = (TQueryable)process.Process(query, DataFilter);
                }
            }

            return query;
        }
    }

    public abstract class RepositoryBase<TEntity, TKey> : RepositoryBase<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot<TKey>
    {
        public abstract Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default);

        public abstract Task<TEntity> FindAsync(TKey id, CancellationToken cancellationToken = default);

        public virtual async Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(id, cancellationToken);

            if (entity == null)
            {
                return;
            }

            await DeleteAsync(entity, autoSave, cancellationToken);
        }

        public virtual async Task DeleteManyAsync(IEnumerable<TKey> ids, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            foreach (var id in ids)
            {
                await DeleteAsync(id, autoSave, cancellationToken);
            }
        }
    }
}

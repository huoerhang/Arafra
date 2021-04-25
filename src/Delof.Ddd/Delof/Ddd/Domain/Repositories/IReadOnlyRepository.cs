using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Delof.Ddd.Domain.Entities;

namespace Delof.Ddd.Domain.Repositories
{
    public interface IReadOnlyRepository<TEntity> : IRepository
        where TEntity:class, IAggregateRoot
    {
        Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);

        ValueTask<long> GetCountAsync(CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetPagedListAsync(int skipCount, int limit, CancellationToken cancellationToken = default);
    }

    public interface IReadOnlyRepository<TEntity,TKey>:IReadOnlyRepository<TEntity>
        where TEntity : class, IAggregateRoot<TKey>
    {
        Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default);

        Task<TEntity> FindAsync(TKey id, CancellationToken cancellationToken = default);
    }
}

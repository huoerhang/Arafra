using Delof.Ddd.Domain.Entities;
using System.Linq;

namespace Delof.Data.Filter
{
    public interface IDataFilterProcesser
    {
        IQueryable<TEntity> Process<TEntity>(IQueryable<TEntity> query,IDataFilter dataFilter)
            where TEntity : IEntity;
    }
}

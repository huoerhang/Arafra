using Andef.Ddd.Domain.Entities;
using System.Linq;

namespace Andef.Data.Filter
{
    public interface IDataFilterProcesser
    {
        IQueryable<TEntity> Process<TEntity>(IQueryable<TEntity> query,IDataFilter dataFilter)
            where TEntity : IEntity;
    }
}

using System.Threading;
using System.Threading.Tasks;

namespace Andef.Ddd.Uow
{
    public interface ISupportRollback
    {
        Task RollbackAsync(CancellationToken cancellationToken);
    }
}

using System.Threading;
using System.Threading.Tasks;

namespace Delof.Ddd.Uow
{
    public interface ISupportRollback
    {
        Task RollbackAsync(CancellationToken cancellationToken);
    }
}

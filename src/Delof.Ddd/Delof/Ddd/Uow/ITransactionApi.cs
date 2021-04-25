using System;
using System.Threading;
using System.Threading.Tasks;

namespace Delof.Ddd.Uow
{
    public interface ITransactionApi : IDisposable
    {
        Task CommitAsync(CancellationToken cancellationToken);
    }
}

using System.Threading;
using System.Threading.Tasks;

namespace Delof.Ddd.Uow
{
    public interface ISupportSavingChanges
    {
        Task SavingChanges(CancellationToken cancellationToken); 
    }
}

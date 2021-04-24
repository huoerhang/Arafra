using System.Threading;
using System.Threading.Tasks;

namespace Andef.Ddd.Uow
{
    public interface ISupportSavingChanges
    {
        Task SavingChanges(CancellationToken cancellationToken); 
    }
}

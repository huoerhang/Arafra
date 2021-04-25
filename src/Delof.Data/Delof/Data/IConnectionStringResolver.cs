using System.Threading.Tasks;

namespace Delof.Data
{
    public interface IConnectionStringResolver
    {
        Task<string> ResolveAsync(string connectionStringName = null);
    }
}

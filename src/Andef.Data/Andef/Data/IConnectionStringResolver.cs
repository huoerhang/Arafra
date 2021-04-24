using System.Threading.Tasks;

namespace Andef.Data
{
    public interface IConnectionStringResolver
    {
        Task<string> ResolveAsync(string connectionStringName = null);
    }
}

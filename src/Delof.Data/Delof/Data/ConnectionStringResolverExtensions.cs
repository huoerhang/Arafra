using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Delof.Data
{
    public static class ConnectionStringResolverExtensions
    {
        public static Task<string> ResolveAsync<T>(this IConnectionStringResolver resolver)
        {
            var type = typeof(T);
            return resolver.ResolveAsync(type);
        }

        public static Task<string> ResolveAsync(this IConnectionStringResolver resolver, Type type)
        {
            var attribute = type.GetTypeInfo().GetCustomAttribute<ConnectionStringNameAttribute>();

            if (attribute != null)
            {
                return resolver.ResolveAsync(attribute.Name);
            }

            return resolver.ResolveAsync(type.FullName);
        }
    }
}

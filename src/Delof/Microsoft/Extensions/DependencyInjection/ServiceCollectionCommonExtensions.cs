using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionCommonExtensions
    {
        public static bool IsAdded(this IServiceCollection services, Type serviceType)
        {
            return services.Any(t => t.ServiceType == serviceType);
        }

        public static bool IsAdded<T>(this IServiceCollection services)
        {
            return services.IsAdded(typeof(T));
        }

        public static void AddRange(this IServiceCollection services, params ServiceDescriptor[] serviceDescriptors)
        {
            if (serviceDescriptors.IsNullOrEmpty())
            {
                return;
            }

            foreach (var item in serviceDescriptors)
            {
                services.Add(item);
            }
        }

        public static T GetFirstInstanceOrNull<T>(this IServiceCollection services)
        {
            var result = services.FirstOrDefault(c => c.ServiceType == typeof(T));

            if (result == null || result.ImplementationInstance == null)
            {
                return default;
            }

            return (T)result.ImplementationInstance;
        }

        public static T GetSingleInstance<T>(this IServiceCollection services)
        {
            var service = services.GetFirstInstanceOrNull<T>();

            if (service == null)
            {
                throw new InvalidOperationException($"Not found service:{typeof(T).AssemblyQualifiedName}");
            }

            return service;
        }
    }
}

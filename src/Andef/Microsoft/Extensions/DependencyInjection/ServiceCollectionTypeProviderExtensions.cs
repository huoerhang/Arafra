using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Andef.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionTypeProviderExtensions
    {
        public static IServiceCollection AddAssemblyOf<T>(this IServiceCollection services)
        {
            return services.AddAssembly(typeof(T).Assembly);
        }

        public static IServiceCollection AddAssembly(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly
                .GetTypes()
                .Where(t => t != null && t.IsClass && !t.IsAbstract && !t.IsGenericType)
                .ToArray();

            services.AddTypes(types);

            return services;
        }

        public static IServiceCollection AddTypes(this IServiceCollection services, params Type[] implementationTypes)
        {
            foreach (var implementationType in implementationTypes)
            {
                services.AddType(implementationType);
            }

            return services;
        }

        public static IServiceCollection AddType<T>(this IServiceCollection services)
        {
            return services.AddType(typeof(T));
        }

        public static IServiceCollection AddType(this IServiceCollection services, Type implementationType)
        {
            var container = services.GetServiceTypeProviders();

            if (!container.IsNullOrEmpty())
            {
                foreach (var item in container)
                {
                    var serviceTypeDescriptor = item.GetServiceTypeDescriptor(implementationType);

                    if (serviceTypeDescriptor == null)
                    {
                        continue;
                    }

                    var serviceDescriptors = serviceTypeDescriptor.BuildServiceDescriptors();
                    services.AddRange(serviceDescriptors.ToArray());
                }
            }

            return services;
        }

        public static IServiceCollection AddServiceTypeProvider(this IServiceCollection services, IServiceTypeProvider serviceTypeProvider)
        {
            services.GetServiceTypeProviders().Add(serviceTypeProvider);

            return services;
        }

        public static ServiceTypeProviderContainer GetServiceTypeProviders(this IServiceCollection services)
        {
            return services.GetOrCreateServiceTypeProviders();
        }

        private static ServiceTypeProviderContainer GetOrCreateServiceTypeProviders(this IServiceCollection services)
        {
            var container = services.GetFirstInstanceOrNull<ObjectAccessor<ServiceTypeProviderContainer>>()?.Value;

            if (container == null)
            {
                container = new ServiceTypeProviderContainer()
                {
                   new DefaultServiceTypeProvider()
                };
                services.AddObjectAccessor(new ObjectAccessor<ServiceTypeProviderContainer>(container));
            }

            return container;
        }
    }
}

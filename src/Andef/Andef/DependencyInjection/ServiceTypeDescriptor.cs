using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Andef.DependencyInjection
{
    public class ServiceTypeDescriptor
    {
        public ServiceTypeDescriptor(IEnumerable<Type> serviceTypes, Type implementationType, ServiceLifetime lifetime)
        {
            serviceTypes.CheckNotNull(nameof(serviceTypes));
            implementationType.CheckNotNull(nameof(implementationType));
            ServiceTypes = serviceTypes;
            ImplementationType = implementationType;
            Lifetime = lifetime;
        }

        public IEnumerable<Type> ServiceTypes { get; private set; }

        public Type ImplementationType { get; private set; }

        public ServiceLifetime Lifetime { get; private set; }

        internal IEnumerable<ServiceDescriptor> BuildServiceDescriptors()
        {
            List<ServiceDescriptor> serviceDescriptors = new List<ServiceDescriptor>();

            foreach(var serviceType in ServiceTypes)
            {
                serviceDescriptors.Add(new ServiceDescriptor(serviceType, ImplementationType, Lifetime));
            }

            return serviceDescriptors;
        }
    }
}

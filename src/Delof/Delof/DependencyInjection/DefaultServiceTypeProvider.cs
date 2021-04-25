using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Delof.DependencyInjection
{
    internal class DefaultServiceTypeProvider : BaseServiceTypeProvider, IServiceTypeProvider
    {
        public override ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType)
        {
            var typeInfo = implementationType.GetTypeInfo();
            var attribute = typeInfo.GetCustomAttribute<DependencyAttribute>(true);

            if (attribute == null)
            {
                return null;
            }

            List<Type> serviceTypes = null;

            if (!attribute.SpecifyServices.IsNullOrEmpty())
            {
                serviceTypes = attribute.SpecifyServices.ToList();
            }
            else
            {
                serviceTypes = typeInfo.GetInterfaces().ToList();
            }

            var lifetime = attribute.Lifetime;

            if (attribute.IncludeSelf || serviceTypes.IsNullOrEmpty())
            {
                if (serviceTypes == null)
                {
                    serviceTypes = new List<Type>();
                }

                serviceTypes.Add(implementationType);
            }

            if (serviceTypes.IsNullOrEmpty())
            {
                return null;
            }

            return new ServiceTypeDescriptor(serviceTypes, implementationType, lifetime);
        }
    }
}

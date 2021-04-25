using System;

namespace Delof.DependencyInjection
{
    public abstract class BaseServiceTypeProvider : IServiceTypeProvider
    {
        public abstract ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType);
    }
}

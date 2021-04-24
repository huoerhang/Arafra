using System;

namespace Andef.DependencyInjection
{
    public abstract class BaseServiceTypeProvider : IServiceTypeProvider
    {
        public abstract ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType);
    }
}

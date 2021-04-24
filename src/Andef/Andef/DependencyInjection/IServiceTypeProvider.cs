using System;

namespace Andef.DependencyInjection
{
    public interface IServiceTypeProvider
    {
        ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType);
    }
}

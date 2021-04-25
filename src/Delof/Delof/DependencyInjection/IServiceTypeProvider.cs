using System;

namespace Delof.DependencyInjection
{
    public interface IServiceTypeProvider
    {
        ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType);
    }
}

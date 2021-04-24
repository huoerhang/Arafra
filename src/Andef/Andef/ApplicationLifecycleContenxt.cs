using System;
using Microsoft.Extensions.DependencyInjection;

namespace Andef
{
    public class ApplicationLifecycleContenxt
    {
        public IServiceProvider ServiceProvider { get; }

        public ApplicationLifecycleContenxt(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        public T GetRequiredService<T>()
            where T : notnull
        {
            return ServiceProvider.GetRequiredService<T>();
        }
    }
}

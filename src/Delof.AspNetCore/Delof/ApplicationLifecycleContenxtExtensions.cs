using Delof.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Delof
{
    public static class ApplicationLifecycleContenxtExtensions
    {
        public static IApplicationBuilder GetApplicationBuilder(this ApplicationLifecycleContenxt context)
        {
            var appBuilder = context.ServiceProvider.GetRequiredService<ObjectAccessor<IApplicationBuilder>>().Value;

            if (appBuilder == null)
            {
                throw new ApplicationInitializationException($"Application's value can not be set.");
            }

            return appBuilder;
        }

        public static IWebHostEnvironment GetEnvironment(this ApplicationLifecycleContenxt context)
        {
            return context.ServiceProvider.GetService<IWebHostEnvironment>();
        }

        public static IConfiguration GetConfiguration(this ApplicationLifecycleContenxt context)
        {
            return context.ServiceProvider.GetRequiredService<IConfiguration>();
        }

        public static ILoggerFactory GetLoggerFactory(this ApplicationLifecycleContenxt context)
        {
            return context.ServiceProvider.GetRequiredService<ILoggerFactory>();
        }
    }
}

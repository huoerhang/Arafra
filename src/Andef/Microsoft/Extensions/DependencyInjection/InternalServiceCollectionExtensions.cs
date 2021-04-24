using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andef;
using Andef.Modularity;
using Andef.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    internal static class InternalServiceCollectionExtensions
    {
        internal static void AddCoreServices(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddLogging();
        }

        internal static void AddCoreAndefServices(this IServiceCollection services, IApplication AndefApplication, ApplicationCreationOptions AndefApplicationCreationOptions)
        {
            var moduleLoader = new ModuleLoader();
            services.TryAddSingleton(moduleLoader);
            services.AddAssemblyOf<IApplication>();
        }
    }
}

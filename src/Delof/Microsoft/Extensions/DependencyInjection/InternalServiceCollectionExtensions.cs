using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delof;
using Delof.Modularity;
using Delof.DependencyInjection;
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

        internal static void AddCoreDelofServices(this IServiceCollection services, IApplication DelofApplication, ApplicationCreationOptions DelofApplicationCreationOptions)
        {
            var moduleLoader = new ModuleLoader();
            services.TryAddSingleton(moduleLoader);
            services.AddAssemblyOf<IApplication>();
        }
    }
}

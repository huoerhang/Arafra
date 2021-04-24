using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andef;
using Andef.Modularity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionApplicationExtensions
    {

        public static IApplication AddApplication<TEntryModule>(this IServiceCollection services, Action<ApplicationCreationOptions> optionsAction = null)
            where TEntryModule : IAndefEntryModule
        {
            return ApplicationFactory.Create<TEntryModule>(services, optionsAction);
        }

        public static IApplication AddApplication(this IServiceCollection services, Type entryModule, Action<ApplicationCreationOptions> optionsAction = null)
        {
            return ApplicationFactory.Create(entryModule, services, optionsAction);
        }
    }
}

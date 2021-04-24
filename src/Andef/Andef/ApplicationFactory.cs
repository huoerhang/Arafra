using Andef.Modularity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Andef
{
    public static class ApplicationFactory
    {
        public static IApplication Create(Type entryModuleType, IServiceCollection services, Action<ApplicationCreationOptions> optionsAction = null)
        {
            return new InternalApplication(entryModuleType, services, optionsAction);
        }

        public static IApplication Create<TEntryModule>(IServiceCollection services, Action<ApplicationCreationOptions> optionsAction = null)
            where TEntryModule : IAndefEntryModule
        {
            return Create(typeof(TEntryModule), services, optionsAction);
        }
    }
}

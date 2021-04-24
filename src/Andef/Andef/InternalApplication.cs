using Andef.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Andef
{
    internal class InternalApplication : ApplicationBase
    {
        public InternalApplication(Type appEntryModuleType, IServiceCollection services, Action<ApplicationCreationOptions> optionsAction)
            : base(appEntryModuleType, services, optionsAction)
        {

        }

        public override void Initialize()
        {
            if (ServiceProvider == null)
            {
                throw new AndefException($"The ServiceProvider is null.");
            }

            InitializeModules();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}

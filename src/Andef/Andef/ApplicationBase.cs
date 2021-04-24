using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Andef.DependencyInjection;
using Andef.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Andef
{
    public abstract class ApplicationBase : IApplication
    {
        protected ApplicationBase(Type appEntryModuleType, IServiceCollection services, Action<ApplicationCreationOptions> optionsAction)
        {
            appEntryModuleType.CheckNotNull(nameof(appEntryModuleType));
            appEntryModuleType.CheckEntryModuleType();
            services.CheckNotNull(nameof(services));

            EntryModuleType = appEntryModuleType;
            Services = services;
            var options = new ApplicationCreationOptions(services);
            optionsAction?.Invoke(options);
            services.AddSingleton<IApplication>(this);
            services.AddSingleton<IModuleContainer>(this);
            services.AddCoreServices();
            services.AddCoreAndefServices(this, options);
            Modules = LoadModules(services, options);
            ConfigureServices();
        }

        public Type EntryModuleType { get; }

        public IServiceCollection Services { get; }

        public IServiceProvider ServiceProvider { get; protected set; }

        public IReadOnlyCollection<AndefModuleDescriptor> Modules { get; }


        public virtual void SetServiceProvider(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            ServiceProvider = serviceProvider;
        }

        protected virtual IReadOnlyCollection<AndefModuleDescriptor> LoadModules(IServiceCollection services, ApplicationCreationOptions options)
        {
            return services.GetSingleInstance<ModuleLoader>().LoadModules(services, EntryModuleType);
        }

        protected virtual void ConfigureServices()
        {
            var context = new ServiceConfigurationContext(Services);
            Services.AddSingleton(context);

            foreach (var module in Modules)
            {
                if (module.Instance is AndefModule AndefModule)
                {
                    AndefModule.ServiceConfigurationContext = context;
                }

                Services.AddAssembly(module.ModuleType.Assembly);
            }

            ExecutePreConfigureServices(context);
            ExecuteConfigureServices(context);
            ExecutePostConfigureServices(context);

            foreach (var module in Modules)
            {
                if (module.Instance is AndefModule AndefModule)
                {
                    AndefModule.ServiceConfigurationContext = null;
                }
            }
        }

        protected virtual void InitializeModules()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = new ApplicationInitializationContext(scope.ServiceProvider);
                scope.ServiceProvider.GetRequiredService<IModuleManager>().InitializeModules(context);
            }
        }

        public virtual void Started()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = new ApplicationStartedContext(scope.ServiceProvider);
                scope.ServiceProvider.GetRequiredService<IModuleManager>().ModulesStarted(context);
            }
        }

        public abstract void Initialize();

        public virtual void Stopping()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = new ApplicationStoppingContext(scope.ServiceProvider);
                scope.ServiceProvider.GetRequiredService<IModuleManager>().ModulesStopping(context);
            }
        }

        public virtual void Dispose()
        {
        }

        private void ExecutePreConfigureServices(ServiceConfigurationContext context)
        {
            try
            {
                foreach (var module in Modules)
                {
                    module.Instance.PreConfigureServices(context);
                }
            }
            catch (Exception ex)
            {
                throw new AndefException($"An error occurred during {nameof(IAndefModule.PreConfigureServices)}. See the inner exception for details.", ex);
            }
        }

        private void ExecuteConfigureServices(ServiceConfigurationContext context)
        {
            try
            {
                foreach (var module in Modules)
                {
                    module.Instance.ConfigureServices(context);
                }
            }
            catch (Exception ex)
            {
                throw new AndefException($"An error occurred during {nameof(IAndefModule.ConfigureServices)}. See the inner exception for details.", ex);
            }
        }

        private void ExecutePostConfigureServices(ServiceConfigurationContext context)
        {
            try
            {
                foreach (var module in Modules)
                {
                    module.Instance.PostConfigureServices(context);
                }
            }
            catch (Exception ex)
            {
                throw new AndefException($"An error occurred during {nameof(IAndefModule.PostConfigureServices)}. See the inner exception for details.", ex);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Delof.DependencyInjection;
using Delof.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Delof
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
            services.AddCoreDelofServices(this, options);
            Modules = LoadModules(services, options);
            ConfigureServices();
        }

        public Type EntryModuleType { get; }

        public IServiceCollection Services { get; }

        public IServiceProvider ServiceProvider { get; protected set; }

        public IReadOnlyCollection<DelofModuleDescriptor> Modules { get; }


        public virtual void SetServiceProvider(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            ServiceProvider = serviceProvider;
        }

        protected virtual IReadOnlyCollection<DelofModuleDescriptor> LoadModules(IServiceCollection services, ApplicationCreationOptions options)
        {
            return services.GetSingleInstance<ModuleLoader>().LoadModules(services, EntryModuleType);
        }

        protected virtual void ConfigureServices()
        {
            var context = new ServiceConfigurationContext(Services);
            Services.AddSingleton(context);

            foreach (var module in Modules)
            {
                if (module.Instance is DelofModule DelofModule)
                {
                    DelofModule.ServiceConfigurationContext = context;
                }

                Services.AddAssembly(module.ModuleType.Assembly);
            }

            ExecutePreConfigureServices(context);
            ExecuteConfigureServices(context);
            ExecutePostConfigureServices(context);

            foreach (var module in Modules)
            {
                if (module.Instance is DelofModule DelofModule)
                {
                    DelofModule.ServiceConfigurationContext = null;
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
                throw new DelofException($"An error occurred during {nameof(IDelofModule.PreConfigureServices)}. See the inner exception for details.", ex);
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
                throw new DelofException($"An error occurred during {nameof(IDelofModule.ConfigureServices)}. See the inner exception for details.", ex);
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
                throw new DelofException($"An error occurred during {nameof(IDelofModule.PostConfigureServices)}. See the inner exception for details.", ex);
            }
        }
    }
}

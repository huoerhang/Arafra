using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using Delof.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Delof.Modularity
{
    [Dependency(ServiceLifetime.Singleton)]
    public class ModuleManager : IModuleManager
    {
        private readonly IModuleContainer _moduleContainer;
        private readonly ILogger<ModuleManager> _logger;
        private readonly IReadOnlyCollection<DelofModuleDescriptor> _moduleDescriptors;
        private IReadOnlyCollection<IApplicationStartedModuleContributor> _startedModules;
        private IReadOnlyCollection<IApplicationStoppingModuleContributor> _stoppingModules;

        private IReadOnlyCollection<IApplicationPreInitializationModuleContributor> _preInitializationModules;
        private IReadOnlyCollection<IApplicationInitializationModuleContributor> _initializationModules;
        private IReadOnlyCollection<IApplicationPostInitializationModuleContributor> _postInitializationModules;


        public ModuleManager(IModuleContainer moduleContainer, ILogger<ModuleManager> logger)
        {
            _moduleContainer = moduleContainer;
            _logger = logger;
            _moduleDescriptors = moduleContainer.Modules;
            FillLifecycleModules();
        }

        public void InitializeModules(ApplicationInitializationContext context)
        {
            try
            {
                ExecutePreApplicationInitialization(context);
                ExecuteApplicationInitialization(context);
                ExecutePostApplicationInitialization(context);
            }
            catch
            {
                throw;
            }

            _logger.LogInformation("Initialized all AppModules.");
        }

        public void ModulesStarted(ApplicationStartedContext context)
        {
            if (_startedModules == null)
            {
                return;
            }

            try
            {
                foreach (var item in _startedModules)
                {
                    item.OnApplicationStarted(context);
                }
            }
            catch
            {
                throw;
            }
        }

        public void ModulesStopping(ApplicationStoppingContext context)
        {
            if (_stoppingModules == null)
            {
                return;
            }

            var reverseDescriptors = _stoppingModules.Reverse().ToList();

            try
            {
                foreach (var item in reverseDescriptors)
                {
                    item.OnApplicationShutdown(context);
                }
            }
            catch
            {
                throw;
            }
        }

        private void ExecutePreApplicationInitialization(ApplicationInitializationContext context)
        {
            ExecuteInitialization(_preInitializationModules, modules =>
            {
                foreach (var item in modules)
                {
                    item.OnPreApplicationInitialization(context);
                }
            });
        }

        private void ExecuteApplicationInitialization(ApplicationInitializationContext context)
        {
            ExecuteInitialization(_initializationModules, modules =>
            {
                foreach (var item in modules)
                {
                    item.OnApplicationInitialization(context);
                }
            });
        }

        private void ExecutePostApplicationInitialization(ApplicationInitializationContext context)
        {
            ExecuteInitialization(_postInitializationModules, modules =>
             {
                 foreach (var item in modules)
                 {
                     item.OnPostApplicationInitialization(context);
                 }
             });
        }

        private void ExecuteInitialization<T>(IReadOnlyCollection<T> modules, Action<IReadOnlyCollection<T>> action)
        {
            if (modules == null)
            {
                return;
            }

            action(modules);
        }

        private void FillLifecycleModules()
        {
            _startedModules = LifecycleModulesFilter<IApplicationStartedModuleContributor>();
            _stoppingModules = LifecycleModulesFilter<IApplicationStoppingModuleContributor>();

            _preInitializationModules = LifecycleModulesFilter<IApplicationPreInitializationModuleContributor>();
            _initializationModules = LifecycleModulesFilter<IApplicationInitializationModuleContributor>();
            _postInitializationModules = LifecycleModulesFilter<IApplicationPostInitializationModuleContributor>();
        }

        private IReadOnlyCollection<T> LifecycleModulesFilter<T>()
        {
            return _moduleDescriptors.Where(c => c.ModuleType.IsAssignableTo<T>()).Select(c => c.Instance)
                 .Cast<T>().ToImmutableList();
        }
    }
}

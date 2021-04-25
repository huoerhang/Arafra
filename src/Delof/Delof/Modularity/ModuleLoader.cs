using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delof.Modularity
{
    internal class ModuleLoader
    {
        public DelofModuleDescriptor[] LoadModules(IServiceCollection services, Type appEntryModuleType)
        {
            services.CheckNotNull(nameof(services));
            appEntryModuleType.CheckEntryModuleType();
            var descriptors = GetAppModuleDescriptors(services, appEntryModuleType);
            var sortedDescriptors = SortByDependency(descriptors, appEntryModuleType);

            return sortedDescriptors.ToArray();
        }

        private List<DelofModuleDescriptor> SortByDependency(List<DelofModuleDescriptor> descriptors, Type appEntryModuleType)
        {
            var sorted = descriptors.SortByDependencies(c => c.Dependencies);
            sorted.MoveItem(c => c.ModuleType == appEntryModuleType, descriptors.Count - 1);

            return sorted;
        }

        private List<DelofModuleDescriptor> GetAppModuleDescriptors(IServiceCollection services, Type appEntryModule)
        {
            var appModuleDescriptors = new List<DelofModuleDescriptor>();
            FillModules(services, appEntryModule, appModuleDescriptors);
            SetDependencies(appModuleDescriptors);

            return appModuleDescriptors;
        }

        private void FillModules(IServiceCollection services, Type appEntryModule, List<DelofModuleDescriptor> appModuleDescriptors)
        {
            foreach (var moduleType in ModuleHelper.FindAllModuleTypes(appEntryModule))
            {
                var moduleDescriptor = CreateModuleDescriptor(services, moduleType);
                appModuleDescriptors.Add(moduleDescriptor);
            }
        }

        private void SetDependencies(List<DelofModuleDescriptor> appModuleDescriptors)
        {
            foreach (var descriptor in appModuleDescriptors)
            {
                SetDependencies(descriptor, appModuleDescriptors);
            }
        }

        private DelofModuleDescriptor CreateModuleDescriptor(IServiceCollection services, Type moduleType)
        {
            var module = CreateAndRegisterModule(services, moduleType);

            return new DelofModuleDescriptor(module);
        }

        private IDelofModule CreateAndRegisterModule(IServiceCollection services, Type moduleType)
        {
            var instance = Activator.CreateInstance(moduleType);

            if (instance == null)
            {
                throw new DelofException($"The instance of type {moduleType.AssemblyQualifiedName} can not create.");
            }

            var module = (IDelofModule)instance;
            services.AddSingleton(moduleType, module);

            return module;
        }

        private void SetDependencies(DelofModuleDescriptor appModuleDescriptor, List<DelofModuleDescriptor> appModuleDescriptors)
        {
            var moduleType = appModuleDescriptor.ModuleType;

            foreach (var dependedModuleType in ModuleHelper.FindDependedModuleTypes(moduleType))
            {
                var depended = appModuleDescriptors.FirstOrDefault(c => c.ModuleType == dependedModuleType);

                if (depended == null)
                {
                    throw new DelofException($"Could not found a depended module {dependedModuleType.AssemblyQualifiedName} ");
                }

                appModuleDescriptor.AddDepoendency(depended);
            }
        }
    }
}

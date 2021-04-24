using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andef.Modularity
{
    internal class ModuleLoader
    {
        public AndefModuleDescriptor[] LoadModules(IServiceCollection services, Type appEntryModuleType)
        {
            services.CheckNotNull(nameof(services));
            appEntryModuleType.CheckEntryModuleType();
            var descriptors = GetAppModuleDescriptors(services, appEntryModuleType);
            var sortedDescriptors = SortByDependency(descriptors, appEntryModuleType);

            return sortedDescriptors.ToArray();
        }

        private List<AndefModuleDescriptor> SortByDependency(List<AndefModuleDescriptor> descriptors, Type appEntryModuleType)
        {
            var sorted = descriptors.SortByDependencies(c => c.Dependencies);
            sorted.MoveItem(c => c.ModuleType == appEntryModuleType, descriptors.Count - 1);

            return sorted;
        }

        private List<AndefModuleDescriptor> GetAppModuleDescriptors(IServiceCollection services, Type appEntryModule)
        {
            var appModuleDescriptors = new List<AndefModuleDescriptor>();
            FillModules(services, appEntryModule, appModuleDescriptors);
            SetDependencies(appModuleDescriptors);

            return appModuleDescriptors;
        }

        private void FillModules(IServiceCollection services, Type appEntryModule, List<AndefModuleDescriptor> appModuleDescriptors)
        {
            foreach (var moduleType in AndefModuleHelper.FindAllModuleTypes(appEntryModule))
            {
                var moduleDescriptor = CreateModuleDescriptor(services, moduleType);
                appModuleDescriptors.Add(moduleDescriptor);
            }
        }

        private void SetDependencies(List<AndefModuleDescriptor> appModuleDescriptors)
        {
            foreach (var descriptor in appModuleDescriptors)
            {
                SetDependencies(descriptor, appModuleDescriptors);
            }
        }

        private AndefModuleDescriptor CreateModuleDescriptor(IServiceCollection services, Type moduleType)
        {
            var module = CreateAndRegisterModule(services, moduleType);

            return new AndefModuleDescriptor(module);
        }

        private IAndefModule CreateAndRegisterModule(IServiceCollection services, Type moduleType)
        {
            var instance = Activator.CreateInstance(moduleType);

            if (instance == null)
            {
                throw new AndefException($"The instance of type {moduleType.AssemblyQualifiedName} can not create.");
            }

            var module = (IAndefModule)instance;
            services.AddSingleton(moduleType, module);

            return module;
        }

        private void SetDependencies(AndefModuleDescriptor appModuleDescriptor, List<AndefModuleDescriptor> appModuleDescriptors)
        {
            var moduleType = appModuleDescriptor.ModuleType;

            foreach (var dependedModuleType in AndefModuleHelper.FindDependedModuleTypes(moduleType))
            {
                var depended = appModuleDescriptors.FirstOrDefault(c => c.ModuleType == dependedModuleType);

                if (depended == null)
                {
                    throw new AndefException($"Could not found a depended module {dependedModuleType.AssemblyQualifiedName} ");
                }

                appModuleDescriptor.AddDepoendency(depended);
            }
        }
    }
}

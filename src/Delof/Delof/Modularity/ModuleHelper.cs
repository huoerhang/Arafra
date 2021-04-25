using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Delof.Modularity
{
    internal static class ModuleHelper
    {
        public static List<Type> FindDependedModuleTypes(Type moduleType)
        {
            moduleType.CheckAppModuleType();
            List<Type> dependencies = new List<Type>();
            var dependedTypeProviders = moduleType.GetCustomAttributes().OfType<IDependedTypesProvider>();

            foreach (var provider in dependedTypeProviders)
            {
                foreach (var dependedModuleType in provider.GetDependedTypes())
                {
                    dependencies.AddIfNotContains(dependedModuleType);
                }
            }

            return dependencies;
        }

        public static List<Type> FindAllModuleTypes(Type appEntryModuleType)
        {
            appEntryModuleType.CheckEntryModuleType();

            var moduleTypes = new List<Type>();
            AddModuleAndDependenciesResursively(appEntryModuleType, moduleTypes);

            return moduleTypes;
        }

        private static void AddModuleAndDependenciesResursively(Type moduleType, List<Type> moduleTypes)
        {
            moduleType.CheckAppModuleType();
            moduleTypes.AddIfNotContains(moduleType);

            foreach (var dependedModuleType in FindDependedModuleTypes(moduleType))
            {
                AddModuleAndDependenciesResursively(dependedModuleType, moduleTypes);
            }
        }
    }
}

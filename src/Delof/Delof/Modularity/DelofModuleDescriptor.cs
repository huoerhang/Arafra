using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace Delof.Modularity
{
    public class DelofModuleDescriptor
    {
        private readonly List<DelofModuleDescriptor> _dependencies;

        internal DelofModuleDescriptor(IDelofModule instance)
        {
            ModuleType = instance.GetType();
            Assembly = ModuleType.Assembly;
            Instance = instance;

            _dependencies = new List<DelofModuleDescriptor>();
        }

        public Assembly Assembly { get; }

        public Type ModuleType { get; }

        public IDelofModule Instance { get; }

        public IReadOnlyCollection<DelofModuleDescriptor> Dependencies => _dependencies.ToImmutableList();

        public void AddDepoendency(DelofModuleDescriptor appModuleDescriptor)
        {
            _dependencies.Add(appModuleDescriptor);
        }
    }
}

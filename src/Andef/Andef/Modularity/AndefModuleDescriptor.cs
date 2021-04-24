using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace Andef.Modularity
{
    public class AndefModuleDescriptor
    {
        private readonly List<AndefModuleDescriptor> _dependencies;

        internal AndefModuleDescriptor(IAndefModule instance)
        {
            ModuleType = instance.GetType();
            Assembly = ModuleType.Assembly;
            Instance = instance;

            _dependencies = new List<AndefModuleDescriptor>();
        }

        public Assembly Assembly { get; }

        public Type ModuleType { get; }

        public IAndefModule Instance { get; }

        public IReadOnlyCollection<AndefModuleDescriptor> Dependencies => _dependencies.ToImmutableList();

        public void AddDepoendency(AndefModuleDescriptor appModuleDescriptor)
        {
            _dependencies.Add(appModuleDescriptor);
        }
    }
}

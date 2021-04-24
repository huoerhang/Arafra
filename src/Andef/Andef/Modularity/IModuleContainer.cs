using System.Collections.Generic;

namespace Andef.Modularity
{
    public interface IModuleContainer
    {
        IReadOnlyCollection<AndefModuleDescriptor> Modules { get; }
    }
}

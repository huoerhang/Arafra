using System.Collections.Generic;

namespace Delof.Modularity
{
    public interface IModuleContainer
    {
        IReadOnlyCollection<DelofModuleDescriptor> Modules { get; }
    }
}

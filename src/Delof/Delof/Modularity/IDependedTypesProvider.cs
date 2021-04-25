using System;

namespace Delof.Modularity
{
    public interface IDependedTypesProvider
    {
        Type[] GetDependedTypes();
    }
}

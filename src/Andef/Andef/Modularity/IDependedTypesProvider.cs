using System;

namespace Andef.Modularity
{
    public interface IDependedTypesProvider
    {
        Type[] GetDependedTypes();
    }
}

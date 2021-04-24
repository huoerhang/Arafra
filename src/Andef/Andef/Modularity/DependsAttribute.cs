using System;

namespace Andef.Modularity
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsAttribute : Attribute, IDependedTypesProvider
    {
        private readonly Type[] _dependendTypes;

        public DependsAttribute(params Type[] dependedTypes)
        {
            _dependendTypes = dependedTypes ?? new Type[0];
        }

        public Type[] GetDependedTypes()
        {
            return _dependendTypes;
        }
    }
}

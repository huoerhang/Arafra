using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class TypeExtensions
    {
        public static bool IsAssignableTo(this Type type, Type targetType)
        {
            type.CheckNotNull(nameof(type));
            targetType.CheckNotNull(nameof(targetType));

            return targetType.IsAssignableFrom(type);
        }

        public static bool IsAssignableTo<TTargetType>(this Type sourceType)
        {
            sourceType.CheckNotNull(nameof(sourceType));

            return sourceType.IsAssignableTo(typeof(TTargetType));
        }

        public static Type[] GetBases(this Type sourceType, Type stoppingType, bool includeObject = true)
        {
            sourceType.CheckNotNull(nameof(sourceType));
            List<Type> types = new List<Type>();
            AppendBaseTypes(types, sourceType.BaseType, includeObject, stoppingType);

            return types.ToArray();
        }

        public static Type[] GetBases(this Type sourceType, bool includeObject = true)
        {
            sourceType.CheckNotNull(nameof(sourceType));
            var types = new List<Type>();
            AppendBaseTypes(types, sourceType.BaseType, includeObject);

            return types.ToArray();
        }

        private static void AppendBaseTypes(List<Type> types, Type type, bool includeObject, Type stoppingType = null)
        {
            if (type == null || type == stoppingType)
            {
                return;
            }

            if (!includeObject && type == typeof(object))
            {
                return;
            }

            AppendBaseTypes(types, type.BaseType, includeObject, stoppingType);

            types.Add(type);
        }
    }
}

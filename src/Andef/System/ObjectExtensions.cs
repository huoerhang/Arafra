using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ObjectExtensions
    {

        public static T CheckNotNull<T>(this T source, string parameterName, string message)
            where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(parameterName, message);
            }

            return source;
        }

        public static T CheckNotNull<T>(this T source, string parameterName)
            where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return source;
        }

        public static bool IsDefaultValue<T>(this T source)
        {
            if (!typeof(T).IsValueType || source == null)
            {
                return true;
            }

            return source.Equals(default(T));
        }
    }
}

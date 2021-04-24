using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ComparableExtensions
    {
        public static bool IsBetween<T>(this T value, T minValue, T maxValue)
            where T : IComparable<T>
            => value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0;
    }
}

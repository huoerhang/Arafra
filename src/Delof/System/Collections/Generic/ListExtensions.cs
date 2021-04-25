using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class ListExtensions
    {
        public static void InsertRange<T>(this IList<T> source, int index, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                source.Insert(index++, item);
            }
        }

        public static int FindIndex<T>(this IList<T> source, Predicate<T> match)
        {
            for (var i = 0; i < source.Count; i++)
            {
                if (match(source[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public static void MoveItem<T>(this List<T> source, Predicate<T> match, int targetIndex)
        {
            if (!targetIndex.IsBetween(0, source.Count - 1))
            {
                throw new IndexOutOfRangeException($"The targetIndex must be between 0 and {source.Count - 1}");
            }

            var currentIndex = source.FindIndex(0, match);

            if (currentIndex == targetIndex)
            {
                return;
            }

            var item = source[currentIndex];
            source.RemoveAt(currentIndex);
            source.Insert(targetIndex, item);
        }

        public static T GetOrAdd<T>(this List<T> source, Func<T, bool> match, Func<T> factory)
        {
            var item = source.FirstOrDefault(match);

            if (item == null)
            {
                item = factory();
                source.Add(item);
            }

            return item;
        }
    }
}

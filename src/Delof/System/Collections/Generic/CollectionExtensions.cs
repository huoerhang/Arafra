using System.Linq;

namespace System.Collections.Generic
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
            => source == null || !source.Any();

        public static void AddIfNotContains<T>(this ICollection<T> source, T item)
        {
            source.CheckNotNull(nameof(source));

            if (!source.Contains(item))
            {
                source.Add(item);
            }
        }

        public static void AddIfNotContains<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            source.CheckNotNull(nameof(source));
            items.CheckNotNull(nameof(source));

            foreach (var item in items)
            {
                source.AddIfNotContains(item);
            }
        }

        public static void RemoveAll<T>(this ICollection<T> source, Func<T, bool> predicate)
        {
            source.CheckNotNull(nameof(source));

            foreach (var item in source.Where(predicate))
            {
                source.Remove(item);
            }
        }
    }
}

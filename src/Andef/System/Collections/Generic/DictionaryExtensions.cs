namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {

        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
            where TKey:notnull
            => dictionary.TryGetValue(key, out var val) ? val : default;

        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TKey : notnull
            => dictionary.TryGetValue(key, out var val) ? val : default;

        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> factory)
        {
            if (dictionary.TryGetValue(key, out var val))
            {
                return val;
            }

            return dictionary[key] = factory(key);
        }

        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> factory)
            => dictionary.GetOrAdd(key, k => factory());
    }
}

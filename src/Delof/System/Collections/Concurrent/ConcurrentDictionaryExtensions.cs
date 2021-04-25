namespace System.Collections.Concurrent
{
    public static class ConcurrentDictionaryExtensions
    {
        public static TValue GetOrDefault<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key)
            where TKey : notnull
            => dictionary.TryGetValue(key, out var val) ? val : default;
    }
}

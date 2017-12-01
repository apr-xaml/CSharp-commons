using System;
using System.Collections.Generic;

namespace nIt.nCommon
{
    static public class Singleton
    {
        static public IReadOnlyDictionary<TKey, TValue> Dictionary<TKey, TValue>(TKey key, TValue value)
            where TKey : struct
        {
            return new Dictionary<TKey, TValue>
            {
                { key, value}
            };
        }

        public static IEnumerable<T> Enumerable<T>(T elem)
        {
            return new T[] { elem };
        }

        public static IReadOnlyList<TElement> List<TElement>(TElement key)
        {
            return new[] { key };
        }
    }
}

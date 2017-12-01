using System;
using System.Collections.Generic;
using System.Linq;

namespace nIt.nCommon
{
    static public class MergeDictionaries
    {
        static public IReadOnlyDictionary<TKey, TValue> AssumingSameKeysHaveSameValues<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> dictX, IReadOnlyDictionary<TKey, TValue> dictY, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueEqComparer = null)
            where TKey : struct
        {
            return _Merge(dictX, dictY, xPair => xPair.Values.Single(), keyComparer, valueEqComparer);
        }


        static public IReadOnlyDictionary<TKey, TValue> AssumingSameKeysHaveSameValues<TKey, TValue>(IDictionary<TKey, TValue> dictX, IDictionary<TKey, TValue> dictY, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueEqComparer = null)
            where TKey : struct
        {
            return _Merge(dictX, dictY, xPair => xPair.Values.Single(), keyComparer, valueEqComparer);
        }

        public static IReadOnlyDictionary<TKey, TValue> UsingFunction<TKey, TValue>(IDictionary<TKey, TValue> dictX, IDictionary<TKey, TValue> dictY, Func<Pair<TValue>, TValue> oxMerge, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueEqComparer = null)
             where TKey : struct
        {
            return _Merge(dictX, dictY, oxMerge, keyComparer, valueEqComparer);
        }

        public static IReadOnlyDictionary<TKey, TValue> UsingFunction<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> dictX, IReadOnlyDictionary<TKey, TValue> dictY, Func<Pair<TValue>, TValue> oxMerge, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueEqComparer = null)
             where TKey : struct
        {
            return _Merge(dictX, dictY, oxMerge, keyComparer, valueEqComparer);

        }

        private static IReadOnlyDictionary<TKey, TValue> _Merge<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> dictX, IEnumerable<KeyValuePair<TKey, TValue>> dictY, Func<Pair<TValue>, TValue> oxMerge, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
             where TKey : struct
        {

            var union = Enumerable
                .Union(dictX, dictY)
                .ToLookup(x => x.Key, keyComparer);

            var simple = union
                .Where(x => x.Count() == 1)
                .Select(x => new KeyValuePair<TKey, TValue>(x.Key, x.Single().Value))
                ;

            var complex = from x in union.Where(x => x.Count() == 2)
                          let values = x.ToArray()
                          let pair = new Pair<TValue>(values[0].Value, values[1].Value)
                          let mergedValue = oxMerge(pair)
                          select new KeyValuePair<TKey, TValue>(x.Key, mergedValue)
                          ;

            return Enumerable
                .Union(simple, complex)
                .ToDictionary(keyComparer);
        }
    }
}

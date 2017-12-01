using System;
using System.Collections.Generic;
using System.Linq;

namespace nIt.nCommon
{
    static public class ext_IEnumerableOfKeyValuePair
    {
        static public IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> _this, IEqualityComparer<TKey> keyComparer)
        {
            return _this.ToDictionary(x => x.Key, x => x.Value, keyComparer);
        }


        static public IReadOnlyDictionary<TKey, TValue> ToDictionaryWithNew<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> _this, TKey key, TValue value, IEqualityComparer<TKey> keyComparer)
            where TKey : struct
        {
            return Enumerable
                .Union(_this, new[] { new KeyValuePair<TKey, TValue>(key, value) })
                .ToDictionary(x => x.Key, x => x.Value, keyComparer);
        }

        static public IReadOnlyDictionary<TKey, TValue> ToDictionaryWithUpdated<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> _this, TKey key, Func<KeyValuePair<TKey, TValue>, TValue> oxUpdate, IEqualityComparer<TKey> keyComparer)
            where TKey : struct
        {

            var oldValue = _this.Single(x => keyComparer.Equals(x.Key, key));

            var newValue = oxUpdate(oldValue);

            var newKv = new[] { new KeyValuePair<TKey, TValue>(key, newValue) };

            var kvComparer = KeyValuePairComparer<TKey, TValue>.Create(keyComparer: keyComparer);

            var thisExcept = _this.Where(x => !keyComparer.Equals(x.Key, key));// !kvComparer.Equals(x, oldValue));
            
            return Enumerable
                .Union(thisExcept, newKv)
                .ToDictionary(x => x.Key, x => x.Value, comparer: keyComparer);
        }
    }
}

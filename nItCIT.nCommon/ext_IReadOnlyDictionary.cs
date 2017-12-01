using System;
using System.Collections.Generic;
using System.Linq;

namespace nIt.nCommon
{
    static public class ext_IReadOnlyDictionary
    {
        static public IReadOnlyDictionary<TKey, TValue> AddOrUpdate<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> _this, TKey key, TValue value, IEqualityComparer<TKey> comparer)
            where TKey : struct
        {
            var newDict = _this.ToDictionary(x => x.Key, x => x.Value, comparer);
            newDict[key] = value;
            return newDict;
        }


        static public IReadOnlyDictionary<TKey, TValue> AddOrUpdateIf<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> _this, TKey key, TValue value, Predicate<TValue> oxUpdateIf, IEqualityComparer<TKey> keyComparer)
            where TKey : struct
        {
            var res = _this.Get(key, keyComparer);

            if (!res.Exists)
            {
                return _this.AddOrUpdate(key, value, keyComparer);
            }
            else
            {
                if (!oxUpdateIf(res.Value))
                {
                    return _this;
                }
                else
                {
                    return _this.AddOrUpdate(key, value, keyComparer);
                }
            }
        }



        static public IReadOnlyDictionary<TKey, TValue> AddOrUpdateWithTransform<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> _this, TKey key, TValue value, Func<TValue, TValue> oxTransform, IEqualityComparer<TKey> comparer)
          where TKey : struct
        {
            var res = _this.Get(key, comparer);

            if (!res.Exists)
            {
                return _this.AddOrUpdate(key, value, comparer);
            }
            else
            {
                var newVal = oxTransform(res.Value);

                return _this.AddOrUpdate(key, newVal, comparer);
            }
        }


        static public IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> _this, IEqualityComparer<TKey> comparer)
            where TKey : struct
        {
            return _this.ToDictionary(x => x.Key, x => x.Value);
        }


        public static Maybe<TValue> Get<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> _this, TKey key, IEqualityComparer<TKey> comparer)
            where TKey : struct
        {

            TValue outVal;
            if (!_this.TryGetValue(key, out outVal))
            {
                return Maybe.NoValue;
            }
            else
            {
                return outVal;
            }

        }


        static public bool IsSubsetOf<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> _this, IReadOnlyDictionary<TKey, TValue> other, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
        {
            return _this.All
                 (
                     x =>
                     {
                         if (!other.ContainsKey(x.Key))
                         {
                             return false;
                         }
                         else
                         {
                             var otherVal = other[x.Key];
                             return valueComparer.Equals(x.Value, otherVal);
                         }
                     }
                 );
        }
    }
}

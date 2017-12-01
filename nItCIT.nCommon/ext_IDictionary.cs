using nIt.nCommon;
using System.Collections.Generic;
using System.Linq;
namespace nIt.nCommon
{
    static public class ext_IDictionary
    {
        public static bool TryUpdate<TKey, TValue>(this IDictionary<TKey, TValue> _this, TKey key, TValue value)
            where TKey : struct
        {
            try
            {
                var oldVal = _this[key];

                if (object.Equals(oldVal, value))
                {
                    return false;
                }
                else
                {
                    _this[key] = value;
                    return true;
                }
            }
            catch (KeyNotFoundException exc)
            {

                throw new KeyNotFoundException(string.Format("Key not found = {0}", key), exc);
            }
        }


        static public IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IDictionary<TKey, TValue> _this, IEqualityComparer<TKey> comparer)
            where TKey : struct
        {
            return _this.ToDictionary(x => x.Key, x => x.Value, comparer);
        }


     

        public static Maybe<TValue> Get<TKey, TValue>(this IDictionary<TKey, TValue> _this, TKey key)
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


    }
}

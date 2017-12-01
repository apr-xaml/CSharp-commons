using System.Collections.Generic;

namespace nIt.nCommon
{
    public class KeyValuePairComparer<TKey, TValue> : IEqualityComparer<KeyValuePair<TKey, TValue>>
        where TKey : struct
    {
        private IEqualityComparer<TKey> _keyComparer;
        private IEqualityComparer<TValue> _valueComparer;

        public KeyValuePairComparer(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
        {
            _keyComparer = keyComparer;
            _valueComparer = valueComparer;
        }

        static public KeyValuePairComparer<TKey, TValue> Create(IEqualityComparer<TKey> keyComparer = null, IEqualityComparer<TValue> valueComparer = null)
        {
            return new KeyValuePairComparer<TKey, TValue>(keyComparer ?? EqualityComparer<TKey>.Default, valueComparer ?? EqualityComparer<TValue>.Default);
        }

        public bool Equals(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
        {
            return _keyComparer.Equals(x.Key, y.Key)
                && _valueComparer.Equals(x.Value, y.Value);
        }

        public int GetHashCode(KeyValuePair<TKey, TValue> obj)
        {
            return _keyComparer.GetHashCode(obj.Key);
        }

       
    }
}

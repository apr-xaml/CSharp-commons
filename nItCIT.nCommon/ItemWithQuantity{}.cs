using System.Collections.Generic;

namespace nIt.nCommon
{
    public class ItemWithQuantity<TValue>
    {
        public ItemWithQuantity(TValue value, int quantity)
        {
            Item = value;
            Quantity = quantity;
        }

        protected static IEqualityComparer<ItemWithQuantity<TValue>> Comparer(IEqualityComparer<TValue> valueComparer)
        {
            return new MyComparer(valueComparer);
        }

        public TValue Item { get; }
        public int Quantity { get; }



        protected virtual ItemWithQuantity<TValue> __Create(TValue value, int quantity)

        {
            return new ItemWithQuantity<TValue>(value, quantity);
        }


        public ItemWithQuantity<TValue> Scale(int factor)
        {
            return __Create(Item, Quantity * factor);
        }


        public ItemWithQuantity<TValue> ChangeQuantity(int newQuantity)
        {
            return __Create(Item, newQuantity);
        }

        private class MyComparer : IEqualityComparer<ItemWithQuantity<TValue>>
        {
            private IEqualityComparer<TValue> _valueComparer;

            public MyComparer(IEqualityComparer<TValue> valueComparer)
            {
                _valueComparer = valueComparer;
            }

            public bool Equals(ItemWithQuantity<TValue> x, ItemWithQuantity<TValue> y)
            {
                return (x.Quantity == y.Quantity)
                    && _valueComparer.Equals(x.Item, y.Item);
            }

            public int GetHashCode(ItemWithQuantity<TValue> obj)
            {
                return _valueComparer.GetHashCode(obj.Item) 
                    ^ obj.Quantity;
            }
        }
    }






}

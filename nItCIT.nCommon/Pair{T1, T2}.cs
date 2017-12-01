using System.Collections.Generic;

namespace nIt.nCommon
{
    public struct Pair<T1, T2>
    {
        public Pair(T1 a, T2 b)
        {
            A = a;
            B = b;
        }

        public T1 A { get; }
        public T2 B { get; }


   


        static public IEqualityComparer<Pair<T1, T2>> Comparer(IEqualityComparer<T1> valueComparer1, IEqualityComparer<T2> valueComparer2) => new MyComparer(valueComparer1, valueComparer2);



        private class MyComparer : IEqualityComparer<Pair<T1, T2>>
        {
            private IEqualityComparer<T1> _valueComparer1;
            private IEqualityComparer<T2> _valueComparer2;

            public MyComparer(IEqualityComparer<T1> valueComparer1, IEqualityComparer<T2> valueComparer2)
            {
                this._valueComparer1 = valueComparer1;
                this._valueComparer2 = valueComparer2;
            }

            public bool Equals(Pair<T1, T2> x, Pair<T1, T2> y)
            {
                return _valueComparer1.Equals(x.A, y.A)
                    && _valueComparer2.Equals(x.B, x.B);
            }

            public int GetHashCode(Pair<T1, T2> obj)
            {
                return _valueComparer1.GetHashCode(obj.A)
                    ^ _valueComparer2.GetHashCode(obj.B);
            }
        }
    }
}

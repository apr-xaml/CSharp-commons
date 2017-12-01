using System;
using System.Collections.Generic;

namespace nIt.nCommon
{
    public struct Pair<T>
    {
        public Pair(T a, T b)
        {
            A = a;
            B = b;
        }

        public T A { get; }
        public T B { get; }

        public IReadOnlyCollection<T> Values { get { return new[] { A, B }; } }

        public Pair<T> Transform(Func<T, T> oxTransform)
        {
            return new Pair<T>(oxTransform(A), oxTransform(B));
        }

        public Pair<TOut> Transform<TOut>(Func<T, TOut> oxTransform)
        {
            return new Pair<TOut>(oxTransform(A), oxTransform(B));
        }


        static public IEqualityComparer<Pair<T>> Comparer(IEqualityComparer<T> valueComparer) => new MyComparer(valueComparer);



        private class MyComparer : IEqualityComparer<Pair<T>>
        {
            private IEqualityComparer<T> _valueComparer;

            public MyComparer(IEqualityComparer<T> valueComparer)
            {
                this._valueComparer = valueComparer;
            }

            public bool Equals(Pair<T> x, Pair<T> y)
            {
                return _valueComparer.Equals(x.A, y.A);
            }

            public int GetHashCode(Pair<T> obj)
            {
                return _valueComparer.GetHashCode(obj.A)
                    ^ _valueComparer.GetHashCode(obj.B);
            }
        }
    }
}

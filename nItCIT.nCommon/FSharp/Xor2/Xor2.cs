using System;
using System.Collections.Generic;

namespace nIt.nCommon
{



    public struct Xor2<TAType, TBType> : IXor2<TAType, TBType>
    {
        private object _obj;
        private readonly Xor2Enum _enum;

        public Xor2(TAType objA)
        {
            _obj = objA;
            _enum = Xor2Enum.A;
        }

        public Xor2(TBType objB)
        {
            _obj = objB;
            _enum = Xor2Enum.B;
        }


        public bool IsA { get { return _obj.IsInstanceOf<TAType>(); } }
        public bool IsB { get { return _obj.IsInstanceOf<TBType>(); } }

        public TAType A { get { return (TAType)_obj; } }

        public TBType B { get { return (TBType)_obj; } }

        public Xor2Enum Kind
            => _enum;





        #region operators
        static public implicit operator Xor2<TAType, TBType>(TAType value)
        {
            return new Xor2<TAType, TBType>(value);
        }

        static public implicit operator Xor2<TAType, TBType>(TBType value)
        {
            return new Xor2<TAType, TBType>(value);
        }
        #endregion


        static public IEqualityComparer<IXor2<TAType, TBType>> Comparer(IEqualityComparer<TAType> comparerA, IEqualityComparer<TBType> comparerB)
        {
            return new MyComparer(comparerA, comparerB);
        }

        private class MyComparer : IEqualityComparer<IXor2<TAType, TBType>>
        {
            private IEqualityComparer<TAType> _comparerA;
            private IEqualityComparer<TBType> _comparerB;

            public MyComparer(IEqualityComparer<TAType> comparerA, IEqualityComparer<TBType> comparerB)
            {
                this._comparerA = comparerA;
                this._comparerB = comparerB;
            }

            public bool Equals(IXor2<TAType, TBType> x, IXor2<TAType, TBType> y)
            {
                if (x.IsA && y.IsA)
                {
                    return _comparerA.Equals(x.A, y.A);
                }

                if (x.IsB && y.IsB)
                {
                    return _comparerB.Equals(x.B, y.B);
                }

                return false;
            }

            public int GetHashCode(IXor2<TAType, TBType> obj)
            {
                if (obj.IsA)
                {
                    return _comparerA.GetHashCode(obj.A);
                }
                else
                {
                    return _comparerB.GetHashCode(obj.B);
                }
            }
        }


    }



}

using nIt.nCommon;
using System;
using System.Collections.Generic;

namespace nIt.nCommon
{



    public struct Xor2<TAType, TBType, TCommon> : IXor2<TAType, TBType, TCommon>
        where TAType : TCommon
        where TBType : TCommon
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

        public Xor2(IXor2<TAType, TBType, TCommon> xor) 
            : this()
        {
            _obj = xor.Common;
        }

        public bool IsA { get { return _obj.IsInstanceOf<TAType>(); } }
        public bool IsB { get { return _obj.IsInstanceOf<TBType>(); } }

        public TAType A { get { return (TAType)_obj; } }


        public TBType B { get { return (TBType)_obj; } }


        public TCommon Common { get { return UnpackXor.ToCommonValue<TCommon>().From(this); } }

        public Xor2Enum Kind
         => _enum;

        public override string ToString() => this.Common.ToString();



        #region operators
        static public implicit operator Xor2<TAType, TBType, TCommon>(TAType value)
        {
            return new Xor2<TAType, TBType, TCommon>(value);
        }

        static public implicit operator Xor2<TAType, TBType, TCommon>(TBType value)
        {
            return new Xor2<TAType, TBType, TCommon>(value);
        }
        #endregion


        static public IEqualityComparer<IXor2<TAType, TBType>> Comparer(IEqualityComparer<TAType> comparerA, IEqualityComparer<TBType> comparerB)
        {
            return new MyXorComparer(comparerA, comparerB);
        }


        static public IEqualityComparerWithReason<IXor2<TAType, TBType>, Xor3<TReasonA, TReasonB, DifferentTypesEnum>> ComparerWithReason<TReasonA, TReasonB>(IEqualityComparerWithReason<TAType, TReasonA> comparerA, IEqualityComparerWithReason<TBType, TReasonB> comparerB)
        {
            return new MyXorComparerWithReason<TReasonA, TReasonB>(comparerA, comparerB);
        }

        public TResult Dispatch<TResult>(Func<TAType, TResult> oxFunc1, Func<TBType, TResult> oxFunc2)
        {
            switch (this.Kind)
            {
                case Xor2Enum.A:
                    return oxFunc1(this.A);
                case Xor2Enum.B:
                    return oxFunc2(this.B);
                default:
                    throw NotPreparedForThatCase.CannotHappenException;
            }
        }

        private class MyXorComparerWithReason<TReasonA, TReasonB> 
            : IEqualityComparerWithReason<IXor2<TAType, TBType>, Xor3<TReasonA, TReasonB, DifferentTypesEnum>>
        {
            private IEqualityComparerWithReason<TAType, TReasonA> _comparerA;
            private IEqualityComparerWithReason<TBType, TReasonB> _comparerB;

            public MyXorComparerWithReason(IEqualityComparerWithReason<TAType, TReasonA> comparerA, IEqualityComparerWithReason<TBType, TReasonB> comparerB)
            {
                this._comparerA = comparerA;
                this._comparerB = comparerB;
            }

            public EqualityResult<IXor2<TAType, TBType>, Xor3<TReasonA, TReasonB, DifferentTypesEnum>> AreEqual(IXor2<TAType, TBType> x, IXor2<TAType, TBType> y)
            {



                if (x.IsA && y.IsA)
                {
                    var res = _comparerA.AreEqual(x.A, y.A);
                    if (res)
                    {
                        return EqualityResult.Ok;
                    }
                    else
                    {
                        return (Xor3<TReasonA, TReasonB, DifferentTypesEnum>)res.NotEqualReason.Value;
                    }
                }

                if (x.IsB && y.IsB)
                {
                    var res = _comparerB.AreEqual(x.B, y.B);
                    if (res)
                    {
                        return EqualityResult.Ok;
                    }
                    else
                    {
                        return (Xor3<TReasonA, TReasonB, DifferentTypesEnum>)res.NotEqualReason.Value;
                    }
                }


                return (Xor3<TReasonA, TReasonB, DifferentTypesEnum>)DifferentTypesEnum.DifferentTypes;

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

        private class MyXorComparer : IEqualityComparer<IXor2<TAType, TBType>>
        {
            private IEqualityComparer<TAType> _comparerA;
            private IEqualityComparer<TBType> _comparerB;

            public MyXorComparer(IEqualityComparer<TAType> comparerA, IEqualityComparer<TBType> comparerB)
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

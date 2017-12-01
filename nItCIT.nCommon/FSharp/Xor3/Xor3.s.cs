using System;
using System.Collections.Generic;

namespace nIt.nCommon
{



    public struct Xor3<TAType, TBType, TCType> : IXor3<TAType, TBType, TCType>

    {
        private object _obj;
        private readonly Xor3Enum _enum;

        public Xor3(TAType objA)
        {
            _obj = objA;
            _enum = Xor3Enum.A;
        }

        public Xor3(TBType objB)
        {
            _obj = objB;
            _enum = Xor3Enum.B;
        }

        public Xor3(TCType objC)
        {
            _obj = objC;
            _enum = Xor3Enum.C;
        }

        public override string ToString()
        {
            if(IsA)
            {
                return this.A.ToString();
            }
            else if(IsB)
            {
                return this.B.ToString();
            }
            else
            {
                return this.C.ToString();
            }
        }
        public bool IsA { get { return _obj.IsInstanceOf<TAType>(); } }
        public bool IsB { get { return _obj.IsInstanceOf<TBType>(); } }

        public bool IsC { get { return _obj.IsInstanceOf<TCType>(); } }

        public TAType A { get { return (TAType)_obj; } }


        public TBType B { get { return (TBType)_obj; } }

        public TCType C { get { return (TCType)_obj; } }

        public Xor3Enum Kind
         => _enum;


        public TResult Dispatch<TResult>(Func<TAType, TResult> oxFunc1, Func<TBType, TResult> oxFunc2, Func<TCType, TResult> oxFunc3)
        {
            switch (this.Kind)
            {
                case Xor3Enum.A:
                    return oxFunc1(this.A);
                case Xor3Enum.B:
                    return oxFunc2(this.B);
                case Xor3Enum.C:
                    return oxFunc3(this.C);
                default:
                    throw NotPreparedForThatCase.CannotHappenException;
            }
        }


        #region operators
        static public implicit operator Xor3<TAType, TBType, TCType>(TAType value)
        {
            return new Xor3<TAType, TBType, TCType>(value);
        }

        static public implicit operator Xor3<TAType, TBType, TCType>(TBType value)
        {
            return new Xor3<TAType, TBType, TCType>(value);
        }

        static public implicit operator Xor3<TAType, TBType, TCType>(TCType value)
        {
            return new Xor3<TAType, TBType, TCType>(value);
        }
        #endregion





    }



}

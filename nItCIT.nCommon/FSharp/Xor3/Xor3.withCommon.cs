using System;
using System.Collections.Generic;

namespace nIt.nCommon
{



    public struct Xor3<TAType, TBType, TCType, TCommon> : IXor3<TAType, TBType, TCType, TCommon>
        where TAType : TCommon
        where TBType : TCommon
        where TCType : TCommon
    {
        private object _obj;
        private readonly Xor3Enum _enum;

        public Xor3(IXor3<TAType, TBType, TCType, TCommon> other)
        {
            _obj = other.Common;
            _enum = other.Kind;
        }

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

        public override string ToString() => this.Common.ToString();

        public bool IsA { get { return _obj.IsInstanceOf<TAType>(); } }
        public bool IsB { get { return _obj.IsInstanceOf<TBType>(); } }

        public bool IsC { get { return _obj.IsInstanceOf<TCType>(); } }

        public TAType A { get { return (TAType)_obj; } }


        public TBType B { get { return (TBType)_obj; } }

        public TCType C { get { return (TCType)_obj; } }


        public TCommon Common { get { return (TCommon)_obj; } }

        public Xor3Enum Kind => _enum;



        #region operators
        static public implicit operator Xor3<TAType, TBType, TCType, TCommon>(TAType value)
        {
            return new Xor3<TAType, TBType, TCType, TCommon>(value);
        }

        static public implicit operator Xor3<TAType, TBType, TCType, TCommon>(TBType value)
        {
            return new Xor3<TAType, TBType, TCType, TCommon>(value);
        }

        static public implicit operator Xor3<TAType, TBType, TCType, TCommon>(TCType value)
        {
            return new Xor3<TAType, TBType, TCType, TCommon>(value);
        }
        #endregion





    }



}

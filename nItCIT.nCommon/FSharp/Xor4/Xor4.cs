using System;
using System.Collections.Generic;

namespace nIt.nCommon
{



    public struct Xor4<TA, TB, TC, TD, TCommon> : IXor4<TA, TB, TC, TD, TCommon>
        where TA : TCommon
        where TB : TCommon
        where TC : TCommon
        where TD : TCommon
    {
        private object _obj;
        private readonly Xor4Enum _enum;

        public Xor4(TA objA)
        {
            _obj = objA;
            _enum = Xor4Enum.A;
        }

        public Xor4(TB objB)
        {
            _obj = objB;
            _enum = Xor4Enum.B;
        }

        public Xor4(TC objC)
        {
            _obj = objC;
            _enum = Xor4Enum.C;
        }

        public Xor4(TD objD)
        {
            _obj = objD;
            _enum = Xor4Enum.D;
        }

        public override string ToString() => this.Common.ToString();
        public bool IsA => _obj.IsInstanceOf<TA>();
        public bool IsB => _obj.IsInstanceOf<TB>();
        public bool IsC => _obj.IsInstanceOf<TC>();
        public bool IsD => _obj.IsInstanceOf<TD>();

        public TCommon Common => (TCommon)_obj;

        public TA A => (TA)_obj;
        public TB B => (TB)_obj;
        public TC C => (TC)_obj;
        public TD D => (TD)_obj;

        public Xor4Enum Kind => _enum;




        #region operators
        static public implicit operator Xor4<TA, TB, TC, TD, TCommon>(TA value)
        {
            return new Xor4<TA, TB, TC, TD, TCommon>(value);
        }

        static public implicit operator Xor4<TA, TB, TC, TD, TCommon>(TB value)
        {
            return new Xor4<TA, TB, TC, TD, TCommon>(value);
        }

        static public implicit operator Xor4<TA, TB, TC, TD, TCommon>(TC value)
        {
            return new Xor4<TA, TB, TC, TD, TCommon>(value);
        }

        static public implicit operator Xor4<TA, TB, TC, TD, TCommon>(TD value)
        {
            return new Xor4<TA, TB, TC, TD, TCommon>(value);
        }
        #endregion





    }



}

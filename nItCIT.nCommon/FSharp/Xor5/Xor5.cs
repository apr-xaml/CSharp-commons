using System;
using System.Collections.Generic;

namespace nIt.nCommon
{



    public struct Xor5<TA, TB, TC, TD, TE, TCommon> : IXor5<TA, TB, TC, TD, TE, TCommon>
        where TA : TCommon
        where TB : TCommon
        where TC : TCommon
        where TD : TCommon
        where TE : TCommon
    {
        private object _obj;
        private readonly Xor5Enum _enum;

        public Xor5(TA objA)
        {
            _obj = objA;
            _enum = Xor5Enum.A;
        }

        public Xor5(TB objB)
        {
            _obj = objB;
            _enum = Xor5Enum.B;
        }

        public Xor5(TC objC)
        {
            _obj = objC;
            _enum = Xor5Enum.C;
        }

        public Xor5(TD objD)
        {
            _obj = objD;
            _enum = Xor5Enum.D;
        }

        public Xor5(TE objE)
        {
            _obj = objE;
            _enum = Xor5Enum.E;
        }

        public override string ToString() => this.Common.ToString();

        public bool IsA => _obj.IsInstanceOf<TA>();
        public bool IsB => _obj.IsInstanceOf<TB>();
        public bool IsC => _obj.IsInstanceOf<TC>();
        public bool IsD => _obj.IsInstanceOf<TD>();

        public bool IsE => _obj.IsInstanceOf<TE>();


        public TCommon Common => (TCommon)_obj;

        public TA A => (TA)_obj;
        public TB B => (TB)_obj;
        public TC C => (TC)_obj;
        public TD D => (TD)_obj;

        public TE E => (TE)_obj;

        public Xor5Enum Kind => _enum;




        #region operators
        static public implicit operator Xor5<TA, TB, TC, TD, TE, TCommon>(TA value)
        {
            return new Xor5<TA, TB, TC, TD, TE, TCommon>(value);
        }

        static public implicit operator Xor5<TA, TB, TC, TD, TE, TCommon>(TB value)
        {
            return new Xor5<TA, TB, TC, TD, TE, TCommon>(value);
        }

        static public implicit operator Xor5<TA, TB, TC, TD, TE, TCommon>(TC value)
        {
            return new Xor5<TA, TB, TC, TD, TE, TCommon>(value);
        }

        static public implicit operator Xor5<TA, TB, TC, TD, TE, TCommon>(TD value)
        {
            return new Xor5<TA, TB, TC, TD, TE, TCommon>(value);
        }

        static public implicit operator Xor5<TA, TB, TC, TD, TE, TCommon>(TE value)
        {
            return new Xor5<TA, TB, TC, TD, TE, TCommon>(value);
        }


        #endregion





    }



}

using System;
using System.Collections.Generic;

namespace nIt.nCommon
{



    public struct Xor6<TA, TB, TC, TD, TE, TF, TCommon> : IXor6<TA, TB, TC, TD, TE, TF, TCommon>
        where TA : TCommon
        where TB : TCommon
        where TC : TCommon
        where TD : TCommon
        where TE : TCommon
        where TF : TCommon
    {
        private object _obj;
        private readonly Xor6Enum _enum;

        public Xor6(TA objA)
        {
            _obj = objA;
            _enum = Xor6Enum.A;
        }

        public Xor6(TB objB)
        {
            _obj = objB;
            _enum = Xor6Enum.B;
        }

        public Xor6(TC objC)
        {
            _obj = objC;
            _enum = Xor6Enum.C;
        }

        public Xor6(TD objD)
        {
            _obj = objD;
            _enum = Xor6Enum.D;
        }

        public Xor6(TE objE)
        {
            _obj = objE;
            _enum = Xor6Enum.E;
        }
        public Xor6(TF objF)
        {
            _obj = objF;
            _enum = Xor6Enum.F;
        }

        public override string ToString() => this.Common.ToString();

        public bool IsA => _obj.IsInstanceOf<TA>();
        public bool IsB => _obj.IsInstanceOf<TB>();
        public bool IsC => _obj.IsInstanceOf<TC>();
        public bool IsD => _obj.IsInstanceOf<TD>();

        public bool IsE => _obj.IsInstanceOf<TE>();
        public bool IsF => _obj.IsInstanceOf<TF>();

        public TCommon Common => (TCommon)_obj;

        public TA A => (TA)_obj;
        public TB B => (TB)_obj;
        public TC C => (TC)_obj;
        public TD D => (TD)_obj;

        public TE E => (TE)_obj;
        public TF F => (TF)_obj;
        public Xor6Enum Kind => _enum;




        #region operators
        static public implicit operator Xor6<TA, TB, TC, TD, TE, TF, TCommon>(TA value)
        {
            return new Xor6<TA, TB, TC, TD, TE, TF, TCommon>(value);
        }

        static public implicit operator Xor6<TA, TB, TC, TD, TE, TF, TCommon>(TB value)
        {
            return new Xor6<TA, TB, TC, TD, TE, TF, TCommon>(value);
        }

        static public implicit operator Xor6<TA, TB, TC, TD, TE, TF, TCommon>(TC value)
        {
            return new Xor6<TA, TB, TC, TD, TE, TF, TCommon>(value);
        }

        static public implicit operator Xor6<TA, TB, TC, TD, TE, TF, TCommon>(TD value)
        {
            return new Xor6<TA, TB, TC, TD, TE, TF, TCommon>(value);
        }

        static public implicit operator Xor6<TA, TB, TC, TD, TE, TF, TCommon>(TE value)
        {
            return new Xor6<TA, TB, TC, TD, TE, TF, TCommon>(value);
        }

        static public implicit operator Xor6<TA, TB, TC, TD, TE, TF, TCommon>(TF value)
        {
            return new Xor6<TA, TB, TC, TD, TE, TF, TCommon>(value);
        }
        #endregion





    }



}

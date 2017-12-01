using System;
using System.Collections.Generic;

namespace nIt.nCommon
{



    public struct Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon> : IXor7<TA, TB, TC, TD, TE, TF, TG, TCommon>
        where TA : TCommon
        where TB : TCommon
        where TC : TCommon
        where TD : TCommon
        where TE : TCommon
        where TF : TCommon
        where TG : TCommon
    {
        private object _obj;
        private readonly Xor7Enum _enum;

        public Xor7(TA objA)
        {
            _obj = objA;
            _enum = Xor7Enum.A;
        }

        public Xor7(TB objB)
        {
            _obj = objB;
            _enum = Xor7Enum.B;
        }

        public Xor7(TC objC)
        {
            _obj = objC;
            _enum = Xor7Enum.C;
        }

        public Xor7(TD objD)
        {
            _obj = objD;
            _enum = Xor7Enum.D;
        }

        public Xor7(TE objE)
        {
            _obj = objE;
            _enum = Xor7Enum.E;
        }
        public Xor7(TF objF)
        {
            _obj = objF;
            _enum = Xor7Enum.F;
        }

        public Xor7(TG objG)
        {
            _obj = objG;
            _enum = Xor7Enum.G;
        }

        public override string ToString() => this.Common.ToString();

         
        public bool IsA => _obj.IsInstanceOf<TA>();
        public bool IsB => _obj.IsInstanceOf<TB>();
        public bool IsC => _obj.IsInstanceOf<TC>();
        public bool IsD => _obj.IsInstanceOf<TD>();

        public bool IsE => _obj.IsInstanceOf<TE>();
        public bool IsF => _obj.IsInstanceOf<TF>();

        public bool IsG => _obj.IsInstanceOf<TG>();

        public TCommon Common => (TCommon)_obj;

        public TA A => (TA)_obj;
        public TB B => (TB)_obj;
        public TC C => (TC)_obj;
        public TD D => (TD)_obj;

        public TE E => (TE)_obj;
        public TF F => (TF)_obj;

        public TG G => (TG)_obj;
        public Xor7Enum Kind => _enum;




        #region operators
        static public implicit operator Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(TA value)
        {
            return new Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(value);
        }

        static public implicit operator Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(TB value)
        {
            return new Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(value);
        }

        static public implicit operator Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(TC value)
        {
            return new Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(value);
        }

        static public implicit operator Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(TD value)
        {
            return new Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(value);
        }

        static public implicit operator Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(TE value)
        {
            return new Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(value);
        }

        static public implicit operator Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(TF value)
        {
            return new Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(value);
        }

        static public implicit operator Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(TG value)
        {
            return new Xor7<TA, TB, TC, TD, TE, TF, TG, TCommon>(value);
        }
        #endregion





    }



}

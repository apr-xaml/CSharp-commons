using nIt.nCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nItCIT.nCommon.nFSharp
{
    static public class ext_XorClasses
    {
        static public TResult Dispatch<TA, TB, TResult>(this IXor2<TA, TB> _this, Func<TA, TResult> oxFunc1, Func<TB, TResult> oxFunc2)
        {
            switch (_this.Kind)
            {
                case Xor2Enum.A:
                    return oxFunc1(_this.A);
                case Xor2Enum.B:
                    return oxFunc2(_this.B);
                default:
                    throw NotPreparedForThatCase.CannotHappenException;
            }
        }



        static public TResult Dispatch<TA, TB,TC, TResult>(this IXor3<TA, TB, TC> _this, Func<TA, TResult> oxFunc1, Func<TB, TResult> oxFunc2, Func<TC, TResult> oxFunc3)
        {
            switch (_this.Kind)
            {
                case Xor3Enum.A:
                    return oxFunc1(_this.A);
                case Xor3Enum.B:
                    return oxFunc2(_this.B);
                case Xor3Enum.C:
                    return oxFunc3(_this.C);
                default:
                    throw NotPreparedForThatCase.CannotHappenException;
            }
        }


        static public TResult Dispatch<TA, TB, TC, TD, TResult>(this IXor4<TA, TB, TC, TD> _this, Func<TA, TResult> oxFunc1, Func<TB, TResult> oxFunc2, Func<TC, TResult> oxFunc3, Func<TD, TResult> oxFunc4)
        {
            switch (_this.Kind)
            {
                case Xor4Enum.A:
                    return oxFunc1(_this.A);
                case Xor4Enum.B:
                    return oxFunc2(_this.B);
                case Xor4Enum.C:
                    return oxFunc3(_this.C);
                case Xor4Enum.D:
                    return oxFunc4(_this.D);
                default:
                    throw NotPreparedForThatCase.CannotHappenException;
            }
        }
        static public TResult Dispatch<TA, TB, TC, TD, TE, TResult>(this IXor5<TA, TB, TC, TD, TE> _this, Func<TA, TResult> oxFunc1, Func<TB, TResult> oxFunc2, Func<TC, TResult> oxFunc3, Func<TD, TResult> oxFunc4, Func<TE, TResult> oxFunc5)
        {
            switch (_this.Kind)
            {
                case Xor5Enum.A:
                    return oxFunc1(_this.A);
                case Xor5Enum.B:
                    return oxFunc2(_this.B);
                case Xor5Enum.C:
                    return oxFunc3(_this.C);
                case Xor5Enum.D:
                    return oxFunc4(_this.D);
                case Xor5Enum.E:
                    return oxFunc5(_this.E);
                default:
                    throw NotPreparedForThatCase.CannotHappenException;
            }
        }


        static public TResult Dispatch<TA, TB, TC, TD, TE,TF, TResult>(this IXor6<TA, TB, TC, TD, TE, TF> _this, Func<TA, TResult> oxFunc1, Func<TB, TResult> oxFunc2, Func<TC, TResult> oxFunc3, Func<TD, TResult> oxFunc4, Func<TE, TResult> oxFunc5, Func<TF, TResult> oxFunc6)
        {
            switch (_this.Kind)
            {
                case Xor6Enum.A:
                    return oxFunc1(_this.A);
                case Xor6Enum.B:
                    return oxFunc2(_this.B);
                case Xor6Enum.C:
                    return oxFunc3(_this.C);
                case Xor6Enum.D:
                    return oxFunc4(_this.D);
                case Xor6Enum.E:
                    return oxFunc5(_this.E);
                case Xor6Enum.F:
                    return oxFunc6(_this.F);
                default:
                    throw NotPreparedForThatCase.CannotHappenException;
            }
        }

        static public TResult Dispatch<TA, TB, TC, TD, TE, TF, TG, TResult>(this IXor7<TA, TB, TC, TD, TE, TF, TG> _this, Func<TA, TResult> oxFunc1, Func<TB, TResult> oxFunc2, Func<TC, TResult> oxFunc3, Func<TD, TResult> oxFunc4, Func<TE, TResult> oxFunc5, Func<TF, TResult> oxFunc6, Func<TG, TResult> oxFunc7)
        {
            switch (_this.Kind)
            {
                case Xor7Enum.A:
                    return oxFunc1(_this.A);
                case Xor7Enum.B:
                    return oxFunc2(_this.B);
                case Xor7Enum.C:
                    return oxFunc3(_this.C);
                case Xor7Enum.D:
                    return oxFunc4(_this.D);
                case Xor7Enum.E:
                    return oxFunc5(_this.E);
                case Xor7Enum.F:
                    return oxFunc6(_this.F);
                case Xor7Enum.G:
                    return oxFunc7(_this.G);
                default:
                    throw NotPreparedForThatCase.CannotHappenException;
            }
        }
    }
}

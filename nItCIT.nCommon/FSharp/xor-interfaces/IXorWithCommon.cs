using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public interface IXor2<out TA, out TB, out TCommon> : IXor2<TA, TB>
        where TA : TCommon
        where TB : TCommon
    {
        TCommon Common { get; }
    }

    public interface IXor3<out TA, out TB, out TC, out TCommon> : IXor3<TA, TB, TC>
        where TA : TCommon
        where TB : TCommon
        where TC : TCommon
    {

        TCommon Common { get; }
    }


    public interface IXor4<out TA, out TB, out TC, out TD, out TCommon> : IXor4<TA, TB, TC, TD>
        where TA : TCommon
        where TB : TCommon
        where TC : TCommon
        where TD : TCommon
    {

        TCommon Common { get; }
    }


    public interface IXor5<out TA, out TB, out TC, out TD, out TE, out TCommon> : IXor5<TA, TB, TC, TD, TE>
         where TA : TCommon
         where TB : TCommon
         where TC : TCommon
         where TD : TCommon
         where TE : TCommon
    {

        TCommon Common { get; }
    }


    public interface IXor6<out TA, out TB, out TC, out TD, out TE, out TF, out TCommon> : IXor6<TA, TB, TC, TD, TE, TF>
    {

        TCommon Common { get; }
    }


    public interface IXor7<out TA, out TB, out TC, out TD, out TE, out TF, out TG, out TCommon> : IXor7<TA, TB, TC, TD, TE, TF, TG>
    {

        TCommon Common { get; }
    }
}

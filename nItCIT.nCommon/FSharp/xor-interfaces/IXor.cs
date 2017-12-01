using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public interface IXor2<out TA, out TB>
    {
        bool IsA { get; }
        bool IsB { get; }

        TA A { get; }
        TB B { get; }

        Xor2Enum Kind { get; }

    }

    public interface IXor3<out TA, out TB, out TC>
    {
        bool IsA { get; }
        bool IsB { get; }

        bool IsC { get; }

        TA A { get; }
        TB B { get; }

        TC C { get; }

        Xor3Enum Kind { get; }

    }



    public interface IXor4<out TA, out TB, out TC, out TD>
    {
        bool IsA { get; }
        bool IsB { get; }

        bool IsC { get; }

        bool IsD { get; }

        TA A { get; }
        TB B { get; }

        TC C { get; }

        TD D { get; }

        Xor4Enum Kind { get; }

    }


    public interface IXor5<out TA, out TB, out TC, out TD, out TE>
    {
        bool IsA { get; }
        bool IsB { get; }

        bool IsC { get; }

        bool IsD { get; }

        bool IsE { get; }

        TA A { get; }
        TB B { get; }

        TC C { get; }

        TD D { get; }

        TE E { get; }

        Xor5Enum Kind { get; }

    }


    public interface IXor6<out TA, out TB, out TC, out TD, out TE, out TF>
    {
        bool IsA { get; }
        bool IsB { get; }

        bool IsC { get; }

        bool IsD { get; }

        bool IsE { get; }

        bool IsF { get; }

        TA A { get; }
        TB B { get; }

        TC C { get; }

        TD D { get; }

        TE E { get; }

        TF F { get; }

        Xor6Enum Kind { get; }

    }


    public interface IXor7<out TA, out TB, out TC, out TD, out TE, out TF, out TG>
    {
        bool IsA { get; }
        bool IsB { get; }

        bool IsC { get; }

        bool IsD { get; }

        bool IsE { get; }

        bool IsF { get; }

        bool IsG { get; }

        TA A { get; }
        TB B { get; }

        TC C { get; }

        TD D { get; }

        TE E { get; }

        TF F { get; }

        TG G { get; }

        Xor7Enum Kind { get; }

    }
}

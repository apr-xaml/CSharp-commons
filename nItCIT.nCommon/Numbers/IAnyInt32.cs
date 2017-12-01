using System;

namespace nIt.nCommon.nNumbers
{



    public interface IAnyInt32 : IXor3<INegativeInt32, IZeroInt32, IPositiveInt32, IWithSystemInt32Value>
    {
        Int32KindEnum Kind { get; }
    }

    [Flags]
    public enum Int32KindEnum
    {
        Positive = (+1),
        Negative = (-1),
        Zero = 0
    }


    namespace nHelpers
    {

        static public class ext_Int32KindEnum
        {
            static public Int32KindEnum ToNumberEnum(this Int32 _this)
            {
                if (_this == 0)
                {
                    return Int32KindEnum.Zero;
                }
                else if (_this > 0)
                {
                    return Int32KindEnum.Positive;
                }
                else
                {
                    return Int32KindEnum.Negative;
                }
            }
        }
    }
}

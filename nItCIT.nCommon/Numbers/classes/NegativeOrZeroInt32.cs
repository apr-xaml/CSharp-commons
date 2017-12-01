using nIt.nCommon.nExecutionResult;
using nIt.nCommon.nNumbers.nHelpers;
using System;

namespace nIt.nCommon.nNumbers
{
    public struct NegativeOrZeroInt32 : IAnyInt32, IWithSystemInt32Value
    {
        public static implicit operator Int32(NegativeOrZeroInt32 wrapper) => wrapper.Int32Value;
        public static implicit operator NegativeOrZeroInt32(Int32 value) => new NegativeOrZeroInt32(value);

        public static PositiveOrZeroInt32 operator -(NegativeOrZeroInt32 wrapper) => Int32Algebra.OpositeOf(wrapper);


        Xor3<int, int, int, int> _xor3;

        public NegativeOrZeroInt32(int value)
        {

            _AssertNumber.IsNegativeOrZero(value);
            _xor3 = _CreateXor3.FromValue(value);
        }



        public int Int32Value => _xor3.Common;

        public Int32KindEnum Kind => Int32Value.ToNumberEnum();

        public IWithSystemInt32Value Common => this;

        public bool IsA => _xor3.IsA;

        public bool IsB => _xor3.IsB;

        public bool IsC => _xor3.IsC;

        public INegativeInt32 A => Return.OnlyIf(new NegativeInt32(_xor3.A), IsA);

        public IZeroInt32 B => Return.OnlyIf(new ZeroInt32(_xor3.B), IsB);

        public IPositiveInt32 C => Return.OnlyIf(new PositiveInt32(_xor3.C), IsC);

        Xor3Enum IXor3<INegativeInt32, IZeroInt32, IPositiveInt32>.Kind => _xor3.Kind;
    }
}

using nIt.nCommon.nNumbers.nHelpers;
using System;

namespace nIt.nCommon.nNumbers
{
    public struct PositiveOrZeroInt32 : IAnyInt32, IWithSystemInt32Value
    {
        private readonly Xor3<int, int, int, int> _xor3;

        public static implicit operator Int32(PositiveOrZeroInt32 wrapper) => wrapper.Int32Value;

        public static NegativeOrZeroInt32 operator -(PositiveOrZeroInt32 wrapper) => Int32Algebra.OpositeOf(wrapper);



        public PositiveOrZeroInt32(int value)
        {
            _AssertNumber.IsPositiveOrZero(value);
            _xor3 = _CreateXor3.FromValue(value);
        }

        public int Int32Value => _xor3.Common;

        public Int32KindEnum Kind => _xor3.Common.ToNumberEnum();

        public IWithSystemInt32Value Common => this;

        public bool IsA => _xor3.IsA;

        public bool IsB => _xor3.IsB;

        public bool IsC => _xor3.IsC;

        public INegativeInt32 A => new NegativeInt32(_xor3.A);

        public IZeroInt32 B => new ZeroInt32(_xor3.B);

        public IPositiveInt32 C => new PositiveInt32(_xor3.C);

        Xor3Enum IXor3<INegativeInt32, IZeroInt32, IPositiveInt32>.Kind => _xor3.Kind;
    }
}

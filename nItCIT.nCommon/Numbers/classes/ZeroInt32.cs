using nIt.nCommon.nNumbers;

namespace nIt.nCommon.nNumbers
{
    public struct ZeroInt32 : IZeroInt32
    {
        public ZeroInt32(int value)
        {
            _AssertNumber.IsZero(value);
            Int32Value = value;
        }

        public int Int32Value { get; }
    }
}

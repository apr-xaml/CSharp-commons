namespace nIt.nCommon.nNumbers
{
    public struct PositiveInt32 : IPositiveInt32
    {
        public int Int32Value { get; }
        public PositiveInt32(int value)
        {
            _AssertNumber.IsPositive(value);
            Int32Value = value;
        }
    }
}

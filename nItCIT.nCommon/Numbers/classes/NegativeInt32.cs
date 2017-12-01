namespace nIt.nCommon.nNumbers
{
    public struct NegativeInt32 : INegativeInt32
    {


        public NegativeInt32(int value)
        {
            _AssertNumber.IsNegative(value);
            Int32Value = value;
        }

        public int Int32Value { get; }



    }
}

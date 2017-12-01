namespace nIt.nCommon.nNumbers
{
    static class _CreateXor3
    {
        static public Xor3<int, int, int, int> FromValue(int value)
        {
            if (value < 0)
            {
                return new Xor3<int, int, int, int>(objA: value);
            }
            else if (value == 0)
            {
                return new Xor3<int, int, int, int>(objB: value);
            }
            else
            {
                return new Xor3<int, int, int, int>(objC: value);
            }
        }
    }
}

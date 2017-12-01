using nIt.nCommon.nAsserions;

namespace nIt.nCommon.nNumbers
{
    static class _AssertNumber
    {
        public static void IsNegativeOrZero(int value)
        {
            var ok = (value <= 0);
            _Assert.IsTrue(ok);
        }

        static public void IsPositive(int value)
        {
            var ok = (value > 0);
            _Assert.IsTrue(ok);
        }

        static public void IsZero(int value)
        {
            var ok = (value == 0);
            _Assert.IsTrue(ok);
        }

        public static void IsPositiveOrZero(int value)
        {
            var ok = (value >= 0);
            _Assert.IsTrue(ok);
        }

        public static void IsNegative(int value)
        {
            var ok = (value < 0);
            _Assert.IsTrue(ok);
        }
    }
}

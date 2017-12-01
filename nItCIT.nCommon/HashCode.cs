using System.Linq;

namespace nIt.nCommon
{
    static public class HashCode
    {
        public const int Prime1 = 17;
        public const int Prime2 = 23;


        static public int Of(object val0, params object[] values)
            => Of(val0.GetHashCode(), values.Select(x => x.GetHashCode()).ToArray());
       

        static public int Of(int val0, params int[] values)
        {

            unchecked
            {
                var hash = Prime1;

                foreach (var iVal in values)
                {
                    hash = hash * Prime2 + iVal;
                }

                return hash;
            }
        }
    }
}

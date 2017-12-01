using System;

namespace nIt.nCommon
{
    static public class DateTimeComparer 
    {
        static public bool AreEqual(this DateTime x, DateTime y, double delta = 10e5)
        {
            return Math.Abs((x - y).Ticks) < 10e5;
        }
    }
}

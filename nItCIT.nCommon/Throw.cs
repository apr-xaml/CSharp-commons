using System;
using System.Diagnostics;

namespace nIt.nCommon
{
    [DebuggerStepThrough]
    static public class Throw
    {
        
        static public void IfNot(bool condition)
        {
            if (!condition)
            {
                throw new Exception();
            }
        }

        public static void IfNotSharpBetween(int min, int middle, int max)
        {
            var ok = (min < middle) && (middle < max);
            Throw.IfNot(ok);
        }

        public static void If(bool condition)
        {
            if(condition)
            {
                throw new Exception();
            }
        }
    }
}

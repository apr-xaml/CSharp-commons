using System;
using System.Collections.Generic;

namespace nIt.nCommon
{
    static public  class EqComparer
    {
        static readonly public IEqualityComparer<int> Int32 = EqualityComparer<int>.Default;
        static readonly public IEqualityComparer<string> StringOrdinalIgnoreCase = StringComparer.OrdinalIgnoreCase;
    }
}

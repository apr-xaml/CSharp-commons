using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    static public class ListFrom
    {
        static  public IReadOnlyList<TElement> Elements<TElement>(params TElement[] elements)
        {
            return elements.ToArray();
        }
    }
}

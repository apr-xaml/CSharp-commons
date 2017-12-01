using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public interface IAnd<out TA, out TB> 
    {
        TA A { get; }
        TB B { get; }
    }
}

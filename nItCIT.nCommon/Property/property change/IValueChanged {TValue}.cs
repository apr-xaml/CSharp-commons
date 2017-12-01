using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public interface IValueChanged<out TValue> : IValueChanged
    {
        new TValue NewValue { get; }
        new TValue OldValue { get; }
    }

}

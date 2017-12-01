using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public class ValueWithIndex<T>
    {
        public ValueWithIndex(T value, int index)
        {
            Value = value;
            Index = index;
        }

        public int Index { get; }
        public T Value { get; }
    }
}

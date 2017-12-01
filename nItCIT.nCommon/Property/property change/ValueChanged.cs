using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public class ValueChanged<TValue> : IValueChanged<TValue>
    {
        public ValueChanged(TValue oldValue, TValue newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        public TValue NewValue { get; }
        public TValue OldValue { get; }

        object IValueChanged.NewValue => NewValue;

        object IValueChanged.OldValue => OldValue;

    }
}

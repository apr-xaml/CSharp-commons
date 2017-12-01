using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public interface IObservableProperty<TValue> : IDisposable 
    {
        TValue GetValue();
        ISubscription AddSubscribtion(Action<IValueChanged<TValue>> handler);
    }
}

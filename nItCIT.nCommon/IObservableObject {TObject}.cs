using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{

    public interface IObservableObject
    {

        ISubscription Subscribe(Action<IPropertyChanged> handler);
    }
    public interface IObservableObject<TObject> : IObservableObject, IAnd<IObservableObject, TObject>
        where TObject : class
    {

        ISubscription Subscribe(Action<IPropertyChanged<TObject>> handler);
        TObject Insider { get; }
    }




}

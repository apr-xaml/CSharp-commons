using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;

namespace nIt.nCommon
{
    [DebuggerStepThrough]
    static public class ext_NotifyCollectionChangedEventHandler
    {

        static public void FireWhenAdded(this NotifyCollectionChangedEventHandler _this, INotifyPropertyChanged sender, object newItem, int index)
        {
            if (_this != null)
            {
                _this.Invoke(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newItem, index));
            }
        }






        static public void ForwardTo<TItemSource, TItemTarget>(this ObservableCollection<TItemSource> _this, ICollection<TItemTarget> target, Func<TItemSource, TItemTarget> oxTransform)
        {
            Contract.Requires<ArgumentNullException>(oxTransform != null);

            _this.CollectionChanged += (xS, xEArgs) =>
            {


                switch (xEArgs.Action)
                {
                    case NotifyCollectionChangedAction.Reset:
                        target.Clear();
                        break;

                    case NotifyCollectionChangedAction.Add:
                        var item = xEArgs
                            .NewItems
                            .Cast<TItemSource>()
                            .Single();

                        var transformed = oxTransform(item);
                        target.Add(transformed);
                        break;

                    case NotifyCollectionChangedAction.Remove:


                        var toRemove = xEArgs
                            .OldItems
                            .Cast<TItemSource>()
                            .Select(oxTransform);


                        foreach (var iToRemove in toRemove)
                        {
                            target.Remove(iToRemove);
                        }

                        break;

                    case NotifyCollectionChangedAction.Move:
                    case NotifyCollectionChangedAction.Replace:
                        throw new NotImplementedException(xEArgs.Action.ToString());

                    default:
                        break;
                }

            };
        }



    }
}

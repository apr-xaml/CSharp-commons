using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public class SubscriptionsHolder : IDisposable
    {
        HashSet<ISubscription> _subscriptions = new HashSet<ISubscription>();

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            if(IsDisposed)
            {
                return;
            }
            
            foreach (var iSub in _subscriptions)
            {
                iSub.Dispose();
            }

            _subscriptions = null;
        }

        public SubscriptionsHolder Add(ISubscription subscription)
        {
            Throw.If(IsDisposed);
            _subscriptions.Add(subscription);
            return this;
        }
    }
}

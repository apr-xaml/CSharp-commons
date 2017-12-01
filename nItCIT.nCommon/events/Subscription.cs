using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public class Subscription : ISubscription
    {
        private readonly Action _oxUnSubscribeAction;

        public Subscription(Action oxUnsubscribeAction)
        {
            _oxUnSubscribeAction = oxUnsubscribeAction;
        }

        public void Dispose()
        {
            _oxUnSubscribeAction();
        }
    }
}

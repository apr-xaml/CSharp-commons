using System;
using System.Linq;
namespace nIt.nCommon
{
    static public class ext_AggregateException
    {
        static public string  SingleMessage(this AggregateException _this)
        {
            return _this.Flatten().InnerExceptions.Single().Message;
        }
    }
}

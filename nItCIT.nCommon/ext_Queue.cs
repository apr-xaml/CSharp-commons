using System;
using System.Collections.Generic;
namespace nIt.nCommon
{
    static public class ext_Queue
    {
        static public IEnumerable<TItem> Consume<TItem>(this Queue<TItem> _this)
        {
            while (true)
            {

                TItem item = default(TItem);

                var meBreak = false;

                try
                {
                    item = _this.Dequeue();
                }
                catch (InvalidOperationException)
                {

                    meBreak = true;
                }

                if(meBreak)
                {
                    yield break;
                }
                else
                {
                    yield return item;
                }
                
            }
        }
    }
}

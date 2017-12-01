using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace nIt.nCommon
{
    static public class ext_ObservableCollection
    {
        static public void AddRange<TItem>(this ObservableCollection<TItem> _this, IEnumerable<TItem> newItems)
        {
            foreach (var iItem in newItems)
            {
                _this.Add(iItem);
            }
        }
    }
}

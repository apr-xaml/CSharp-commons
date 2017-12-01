using System.ComponentModel;

namespace nIt.nCommon
{
    static public class ext_INotifyPropertyChanged
    {
        static public TSender SubscribeForChange<TSender>(this TSender _this, PropertyChangedEventHandler handler)
            where TSender : INotifyPropertyChanged
        {
            _this.PropertyChanged += handler;
            return _this;
        }

        static public TSender UnsubscribeForChange<TSender>(this TSender _this, PropertyChangedEventHandler handler)
            where TSender : INotifyPropertyChanged
        {
            _this.PropertyChanged -= handler;
            return _this;
        }
    }
}

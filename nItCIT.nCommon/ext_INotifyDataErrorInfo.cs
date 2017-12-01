using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace nIt.nCommon
{
    static public class ext_INotifyDataErrorInfo
    {
        //static public TSender SubscribeForErrors<TSender>(this TSender _this, EventHandler<DataErrorsChangedEventArgs> handler) where TSender : INotifyDataErrorInfo
        //{
        //    _this.ErrorsChanged += handler;
        //    return _this;
        //}

        //static public TSender UnsubscribeForErrors<TSender>(this TSender _this, EventHandler<DataErrorsChangedEventArgs> handler) where TSender : INotifyDataErrorInfo
        //{
        //    _this.ErrorsChanged -= handler;
        //    return _this;
        //}


        static public void Fire(this EventHandler<DataErrorsChangedEventArgs> _this, INotifyDataErrorInfo sender, [CallerMemberName]string propName = null)
        {
            if (_this != null)
            {
                var eargs = new DataErrorsChangedEventArgs(propName);
                _this.Invoke(sender, eargs);
            }
        }


        static public void Fire(this EventHandler<DataErrorsChangedEventArgs> _this, INotifyDataErrorInfo sender, DataErrorsChangedEventArgs eargs)
        {
            if (_this != null)
            {
                _this.Invoke(sender, eargs);
            }
        }
    }
}

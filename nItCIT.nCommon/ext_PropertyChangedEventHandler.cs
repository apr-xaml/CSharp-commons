using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace nIt.nCommon
{
    [DebuggerStepThrough]
    static public class ext_PropertyChangedEventHandler
    {
        static public void Fire(this PropertyChangedEventHandler _this, INotifyPropertyChanged sender, [CallerMemberName]string propName = null)
        {
            if (_this != null)
            {
                _this.Invoke(sender, new PropertyChangedEventArgs(propName));
            }
        }


        static public void Fire(this PropertyChangedEventHandler _this, INotifyPropertyChanged sender, PropertyChangedEventArgs eargs)
        {
            if (_this != null)
            {
                _this.Invoke(sender, eargs);
            }
        }




    }
}

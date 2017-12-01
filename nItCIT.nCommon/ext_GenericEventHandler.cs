using System;

namespace nIt.nCommon
{
    static public class ext_GenericEventHandler
    {
        static public void Fire(this EventHandler _this, object sender, EventArgs eargs)
        {
            if (_this != null)
            {
                _this.Invoke(sender, eargs);
            }
        }
    }
}

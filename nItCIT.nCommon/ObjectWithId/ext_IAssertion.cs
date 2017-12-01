using System;

namespace nIt.nCommon.nIObjectWithId
{
    static public class ext_IObjectWithId
    {
        static public void IdPositive(this IObjectWithId _this)
        {
            if (!(_this.Id > 0))
            {
                throw new Exception();
            }
        }



    }
}

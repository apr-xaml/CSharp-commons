using System;

namespace nIt.nCommon.nExecutionResult
{
    static public class Return
    {
        static public T OnlyIf<T>(T value, bool assertion)
        {
            if (!assertion)
            {
                throw CannotHappenException;
            }
            else
            {
                return value;
            }
        }




        static public Exception CannotHappenException = new Exception($"{nameof(Return)} assertion failed");
    }
}

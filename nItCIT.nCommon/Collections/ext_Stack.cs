using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nItCIT.nCommon
{
    static public class ext_Stack
    {
        static public Stack<T> WithPushed<T>(this Stack<T> _this, T elem)
        {
            _this.Push(elem);
            return _this;
        }


        static public IReadOnlyList<T> FromTopToBottom<T>(this Stack<T> _this) => _this.ToArray();
    }
}

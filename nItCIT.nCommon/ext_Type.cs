using System;
using System.Diagnostics.Contracts;

namespace nIt.nCommon
{
    static public class ext_Type
    {
        [Pure]
        static public bool HasInstance(this Type _this, object obj)
        {
            var objType = obj.GetType();
            var isAssignable = _this.IsAssignableFrom(objType);
            return isAssignable;
        }

        static public bool Extends<T>(this Type _this)
        {
            var baseType = typeof(T);
            var type = _this;

            return type.Extends(baseType);
        }

        static public bool Extends(this Type _this, Type type)
        {

            return type.IsAssignableFrom(_this);
        }


        static public object GetDefaultValue(this Type _this)
        {
            if(!_this.IsValueType)
            {
                return null;
            }
            else
            {
                return Activator.CreateInstance(_this);
            }
        }
    }

}

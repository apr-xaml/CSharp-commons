using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    static public class TypeOf
    {
        static public Type Property(string shortName, Type owner, BindingFlags bindingFlags = BindingFlags.Default)
        {
            return _TypeOfRec(new[] { shortName }, owner);
        }

        static public Type Property(IReadOnlyList<string> pathName, Type owner)
        {
            return _TypeOfRec(pathName, owner);
        }



        static Type _TypeOfRec(IReadOnlyList<string> remaingPath, Type owner)
        {
            if(!remaingPath.Any())
            {
                return owner;
            }
            else
            {
                var propType = Introspector
                    .GetPublicImplicitInstancePropByShortName(remaingPath.First(), owner)
                    .PropertyType;

                return _TypeOfRec(remaingPath.Skip(1).ToList(), propType);
            }
        }
    }
}

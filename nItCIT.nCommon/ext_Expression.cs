using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace nIt.nCommon
{
    public static class ext_Expression
    {
        static public IReadOnlyCollection<Type> GetTypesOfArgs(this LambdaExpression _this)
        {
            return (_this)
                .Parameters
                .Select(x => x.Type)
                .ToList();
        }



        static public IPropertyDescription ToPropertyDescription(this MemberExpression _this)
        {
            var propMember = (PropertyInfo)_this.Member;

            var ownerType = propMember.DeclaringType;
            var valueType = _this.Type;
            var shortName = propMember.Name;

            return new PropertyDescription(ownerType, valueType, shortName);
        }
    }
}

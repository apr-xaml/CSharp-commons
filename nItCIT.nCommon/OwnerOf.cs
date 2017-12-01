using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace nIt.nCommon
{
    static public class OwnerOf
    {


        public static object Property<TRetVal>(Expression<Func<TRetVal>> exProperty)
        {
            return _GetPropertyOwner(exProperty);
        }

        public static object Property(Expression<Func<object>> exProperty)
        {
            return _GetPropertyOwner(exProperty);
        }

        private static object _GetPropertyOwner(LambdaExpression eProperty)
        {
            Contract.Ensures(Contract.Result<object>() != null);

            Expression ownerExpr = null;

            if (eProperty.Body is MemberExpression)
            {
                var member = (MemberExpression)eProperty.Body;
                ownerExpr = member.Expression;

            }
            else
            {
                var unary = (UnaryExpression)eProperty.Body;
                var member = (MemberExpression)unary.Operand;
                ownerExpr = member.Expression;
            }

            var lambda = Expression.Lambda<Func<object>>(ownerExpr);
            var res = lambda.Compile().Invoke();
            return res;
        }

    

    }
}

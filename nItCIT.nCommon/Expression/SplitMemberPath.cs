using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    static public class SplitMemberPath
    {

        static public IReadOnlyList<MemberExpression> ToMemberExpressions(Expression<Func<object>> exProperty)
        {
            return _ToMemberExpressionsRec(exProperty.Body).ToList();
        }

        static public IReadOnlyList<MemberExpression> ToMemberExpressions<TResult>(Expression<Func<TResult>> exProperty)
        {
            return _ToMemberExpressionsRec(exProperty.Body).ToList();
        }

        static public IReadOnlyList<MemberExpression> ToMemberExpressions<TOwner, TValue>(Expression<Func<TOwner, TValue>> exProperty)
        {
            return _ToMemberExpressionsRec(exProperty.Body).ToList();
        }

        public static IReadOnlyList<string> ToListOfStrings(string propertyPath)
        {
            return propertyPath.Split(FullNameOf.DotSymbol.ToArray());
        }

        static IEnumerable<MemberExpression> _ToMemberExpressionsRec(Expression expression)
        {
            if (expression is MemberExpression)
            {
                var memberEx = (MemberExpression)expression;
                foreach (var iExProp in _ToMemberExpressionsRec(memberEx.Expression))
                {
                    yield return iExProp;
                }
                
                yield return (MemberExpression)expression;
            }
            else if (expression is UnaryExpression)
            {
                var unary = (UnaryExpression)expression;
                foreach (var ieProp in _ToMemberExpressionsRec(unary.Operand))
                {
                    yield return ieProp;
                }
            }
            else
            {
                yield break;
            }
        }
    }
}

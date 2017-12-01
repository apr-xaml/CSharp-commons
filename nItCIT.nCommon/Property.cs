using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace nIt.nCommon
{
    static public class Property
    {
        static public PropertyInfo Of<TType>(string propPath)
        {
            var splitted = propPath.Split('.');
            var type = typeof(TType);

            return _Of(splitted, type: type);
        }

        private static PropertyInfo _Of(IEnumerable<string> splitted, Type type)
        {
            if (splitted.Count() == 1)
            {
                return _DirectOf(splitted.Single(), type);
            }
            else
            {
                var nextPropName = splitted.First();
                var nextType = _DirectOf(nextPropName, type).PropertyType;
                return _Of(splitted.Skip(1), nextType);
            }
        }

        static public bool IsDirectProperty<TAcess, TPropertyValue>(Expression<Func<TAcess, TPropertyValue>> exProperty)
        {
            return SplitMemberPath.ToMemberExpressions(exProperty).Skip(1).Any();
        }

        private static PropertyInfo _DirectOf(string propName, Type type)
        {
            return type.GetProperty(propName, BindingFlags.Instance | BindingFlags.Public);
        }

        public static bool IsNegated(this Expression<Func<bool>> exProp)
        {
            var exprLamb = (LambdaExpression)exProp;
            return _IsBodyNegated(exprLamb.Body, new List<ExpressionType>());
        }

        public static bool IsNegated<TOwner>(Expression<Func<TOwner, bool?>> exProp)
        {
            return _IsBodyNegated(exProp.Body, new List<ExpressionType>());
        }

        public static bool IsNegated<TOwner>(Expression<Func<TOwner, bool>> exProp)
        {
            return _IsBodyNegated(exProp.Body, new List<ExpressionType>());
        }




        private static bool _IsBodyNegated(Expression exp, List<ExpressionType> soFar)
        {

            if (exp.NodeType == ExpressionType.MemberAccess)
            {
                if (!soFar.Any())
                {
                    return false;
                }
                else
                {
                    Contract.Assert(soFar.Count <= 2);
                    return soFar.Last() == ExpressionType.Not;
                }

            }
            else
            {
                var nextInChain = _GetNextInChain(exp);
                soFar.Add(exp.NodeType);
                return _IsBodyNegated(nextInChain, soFar);
            }
        }


        static Expression _GetNextInChain(Expression exp)
        {
            return ((UnaryExpression)exp).Operand;
        }
    }
}

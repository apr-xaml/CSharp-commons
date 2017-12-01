using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace nIt.nCommon
{
    static public class FullNameOf
    {

        public const string DotSymbol = ".";


        static public string From(IReadOnlyList<IPropertyDescription> propertyDescriptions)
        {
            return string.Join(DotSymbol, propertyDescriptions.Select(x => x.ShortName).ToArray());
        }

        [DebuggerStepThrough]
        static public string Property<TOwner, TResult>(Expression<Func<TOwner, TResult>> exProp)
        {
            var members = SplitMemberPath.ToMemberExpressions(exProp).ToList();

            if (!members.Any())
            {
                throw new InvalidOperationException($"Cannot obtain MemberExpression from {exProp}");
            }

            return string.Join(".", members.Select(x => x.Member.Name));
        }

        [DebuggerStepThrough]
        static public string Property<TOwner>(Expression<Func<TOwner, object>> exProp)
        {
            var members = SplitMemberPath.ToMemberExpressions(exProp).ToList();
            return string.Join(".", members.Select(x => x.Member.Name));
        }

        [DebuggerStepThrough]
        static public string Property<TOwner>(Expression<Func<object>> exProp)
        {
            var members = SplitMemberPath.ToMemberExpressions(exProp).ToList();
            return string.Join(".", members.Select(x => x.Member.Name));
        }

        [DebuggerStepThrough]
        static public string Property<TOwner>(TOwner owner, Expression<Func<TOwner, object>> exProp)
        {
            var members = SplitMemberPath.ToMemberExpressions(exProp).ToList();
            return string.Join(".", members.Select(x => x.Member.Name));
        }

        [DebuggerStepThrough]
        public static string Property<TResult>(Expression<Func<TResult>> exProp)
        {

            var members = SplitMemberPath.ToMemberExpressions(exProp).ToList();
            return string.Join(".", members.Select(x => x.Member.Name));

        }



        [Obsolete("Use C# 6 'nameof' instead")]
        public static string Action(Expression<Action> exAction)
        {
            var methodCallExpression = (MethodCallExpression)exAction.Body;
            return methodCallExpression.Method.Name;
        }


        [Obsolete("Use C# 6 'nameof' instead")]
        public static string Delegate(Delegate @delegate)
        {
            return @delegate.GetMethodInfo().Name;
        }
    }

    static public class ShortNameOf
    {
        [DebuggerStepThrough]
        static public string Property<TOwner, TResult>(Expression<Func<TOwner, TResult>> exProp)
        {
            var fullName = FullNameOf.Property(exProp);
            return fullName.Split(FullNameOf.DotSymbol.Single()).Last();
        }
    }
}

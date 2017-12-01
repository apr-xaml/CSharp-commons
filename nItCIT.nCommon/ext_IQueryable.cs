using nIt.nCommon.nIObjectWithId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace nIt.nCommon
{
    public enum SortOrderEnum
    {
        Asc,
        Desc
    }

    static public class ext_IQueryable
    {
        static public IOrderedQueryable<T> OrderByDynamic<T>(this IQueryable<T> _this, Expression<Func<T, object>> startingPropPath, string propPath, SortOrderEnum order)
        {
            var typeOfItems = typeof(T);

            var exParam = Expression.Parameter(typeOfItems);


            var startingProps = FullNameOf.Property(startingPropPath).Split('.');
            var endingProps = propPath.Split('.');

            var fullPropsPath = Enumerable.Concat(startingProps, endingProps);

            var exFullPropPath = _BuildPropertyAccessExpressionRec(exParam, fullPropsPath);

            var exSort = Expression.Lambda(exFullPropPath, exParam);


            var typeOfFinalProperty = exFullPropPath.Type;

            var exCallStaticMethodOnQueryableClass = Expression.Call
                (
                    type: typeof(Queryable),
                    methodName: _GetSortMethodName(order),
                    typeArguments: new[] { typeOfItems, typeOfFinalProperty },
                    arguments: new[] { _this.Expression, exSort }

                );

            var res = _this
                .Provider
                .CreateQuery<T>(exCallStaticMethodOnQueryableClass);

            return (IOrderedQueryable<T>)res; 

        }


        static public string _GetSortMethodName(SortOrderEnum order)
        {
            switch (order)
            {
                case SortOrderEnum.Asc:
                    return "OrderBy";
                case SortOrderEnum.Desc:
                    return "OrderByDescending";
                default:
                    throw new InvalidOperationException("Uknown sorting order = {0}".Form(order));
            }
        }

        private static MemberExpression _BuildPropertyAccessExpressionRec(ParameterExpression expression, IEnumerable<string> props)
        {
            var exFirstProp = Expression.Property(expression, props.First());


            return _BuildPropertyAccessExpression(exFirstProp, props.Skip(1));
        }

        private static MemberExpression _BuildPropertyAccessExpression(MemberExpression expression, IEnumerable<string> props)
        {
            if (!props.Any())
            {
                return expression;
            }


            var exProp = Expression.Property(expression, props.First());


            return _BuildPropertyAccessExpression(exProp, props.Skip(1));
        }




        static public IQueryable<TElem> Page<TElem>(this IQueryable<TElem> _this, IPageInfo pageInfo) where TElem : IObjectWithId
        {
            return _this
                .OrderBy(x => x.Id)
                .Select(x => (TElem)x)
                .Skip(pageInfo.PageNumber * pageInfo.PageSize)
                .Take(pageInfo.PageSize);


        }


        static public IQueryable<TElem> Page<TElem>(this IOrderedQueryable<TElem> _this, IPageInfo pageInfo)
        {
            return _this
                .Skip(pageInfo.PageNumber * pageInfo.PageSize)
                .Take(pageInfo.PageSize);
        }



    }
}

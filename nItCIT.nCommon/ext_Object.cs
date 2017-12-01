using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace nIt.nCommon
{
    static public class ext_Object
    {
        static public bool IsOneOf<TElement>(this TElement _this, TElement elem, params TElement[] restOfElements)
            where TElement : struct
        {
            return _IsInside(_this, elem, restOfElements);
        }

        static public bool IsOneOf<TElement>(this TElement _this, IEnumerable<TElement> elements, IEqualityComparer<TElement> comparer)
             where TElement : class
        {
            return elements.Contains(_this, comparer);
        }

        static public bool IsOneOf(this string _this, string elem, params string[] restOfElements)
        {
            return _IsInside(_this, elem, restOfElements);
        }

        static public bool IsOneOf<TElement>(this TElement _this, IEnumerable<TElement> elements)
             where TElement : struct
        {
            return elements.Contains(_this);
        }

        static public bool IsOneOf(this string _this, IEnumerable<string> elements)
        {
            return elements.Contains(_this);
        }

        private static bool _IsInside<TElement>(TElement _this, TElement elem, TElement[] restOfElements)
        {
            return Enumerable
                .Union(new[] { elem }, restOfElements.ToArray())
                .Contains(_this);
        }


        static public IReadOnlyList<TElement> IntoList<TElement>(this TElement _this) => new[] { _this };


        //static public TCollection IntoCollection<TElement, TCollection, TCollectionElement>(this TElement _this)
        //    where TCollection : ICollection<TCollectionElement>, new()
        //    where TElement : TCollectionElement
        //{
        //    var collection = new TCollection();
        //    collection.Add(_this);
        //    return collection;
        //}

        [Pure]
        static public bool IsInstanceOf<TTYpe>(this object _this)
        {
            var objType = _this.GetType();
            var isAssignable = typeof(TTYpe).IsAssignableFrom(objType);
            return isAssignable;
        }

        static public T NewIfNull<T>(this T _this)
            where T : class, new()
        {

            if (_this != null)
            {
                return _this;
            }
            else
            {
                return new T();
            }
        }

        static public T IfNull<T>(this T _this, T value)
            where T : class
        {

            if (_this != null)
            {
                return _this;
            }
            else
            {
                return value;
            }
        }

    }


    static public class Assign
    {
        static public T ToFrom<T>(ref T refTarget, object value)
        {
            refTarget = (T)value;
            return refTarget;
        }
    }
}

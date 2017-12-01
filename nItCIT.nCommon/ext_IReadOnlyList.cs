using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    static public class ext_IReadOnlyList
    {
        static public IReadOnlyList<TElement> Add<TElement>(this IReadOnlyList<TElement> _this, TElement item, params TElement[] items)
        {
            return Enumerable
                .Concat(_this, items)
                .Concat(Singleton.List(item))
                .ToArray();
        }


        static public IReadOnlyList<TElement> AsRO<TElement>(this IReadOnlyList<TElement> _this)
            => _this;

        static public void Deconstruct<T>(this IReadOnlyList<T> _this, out T firstElem, out IReadOnlyList<T> rest)
        {
            firstElem = _this[0];
            rest = _this.Skip(1).ToList();
        }

        static public void Deconstruct<T>(this IReadOnlyList<T> _this, out T firstElem, out T secondElem, out IReadOnlyList<T> rest)
        {
            firstElem = _this[0];
            secondElem = _this[1];
            rest = _this.Skip(2).ToList();
        }

        static public void Deconstruct<T>(this IReadOnlyList<T> _this, out T firstElem, out T secondElem, out T thirdElem, out IReadOnlyList<T> rest)
        {
            firstElem = _this[0];
            secondElem = _this[1];
            thirdElem = _this[2];
            rest = _this.Skip(2).ToList();
        }
    }
}

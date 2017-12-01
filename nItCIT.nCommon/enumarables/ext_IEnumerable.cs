using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace nIt.nCommon
{
    static public class ext_IEnumerable
    {



        static public IReadOnlyList<T> EmptyIfNull<T>(this IEnumerable<T> _this) => (_this == null) ? Empty.List<T>() : _this.ToArray(); 


        static public IEnumerable<T> Repeat<T>(this IEnumerable<T> _this)
        {
            while (true)
            {
                using (var it = _this.GetEnumerator())
                {
                    while (it.MoveNext())
                    {
                        yield return it.Current;
                    }
                }
            }

        }

        static public IEnumerable<ValueWithIndex<T>> WithIndexes<T>(this IEnumerable<T> _this)
        {
            return _this.Select((x, i) => new ValueWithIndex<T>(x, i));
        }


        static public IEnumerable<T> Add<T>(this IEnumerable<T> _this, T newElement)
        {
            return _this.Concat(Singleton.List(newElement));
        }

        static public bool IsSubsetOf<T>(this IEnumerable<T> _this, IEnumerable<T> other, IEqualityComparer<T> comparer)
        {
            return _this.All(x => other.Contains(x, comparer));
        }

        [DebuggerStepThrough]
        static public IEnumerable<TResult> SelectWithHistory<TElem, TResult>(this IEnumerable<TElem> _this, Func<TElem, TResult> oxStart, Func<TElem, TResult, TResult> oxNext, Func<TElem, TResult, TResult> oxOnLast = null)
        {
            if (!_this.Any())
            {
                yield break;
            }

            var first = _this.First();
            var firstAccum = oxStart(first);

            yield return firstAccum;

            var iAccum = firstAccum;

            var remaining = _this.Skip(1);

            var remainingCount = remaining.Count();

            foreach (var iElemWithIndex in remaining.WithIndexes())
            {
                var iElem = iElemWithIndex.Value;

                if ((iElemWithIndex.Index == (remainingCount - 1)) && (oxOnLast != null))
                {
                    iAccum = oxOnLast(iElem, iAccum);
                    yield return iAccum;
                }
                else
                {
                    iAccum = oxNext(iElem, iAccum);
                    yield return iAccum;
                }


            }
        }


        //[DebuggerStepThrough]
        static public IEnumerable<TRes> SelectWithHistory<TElem, TPassingData, TRes>(this IEnumerable<TElem> _this, Func<TElem, Pair<TRes, TPassingData>> oxStart, Func<TElem, TPassingData, Pair<TRes, TPassingData>> oxNext)
        {
            if (!_this.Any())
            {
                yield break;
            }

            var first = _this.First();
            var firstPair = oxStart(first);

            yield return firstPair.A;

            var iPair = firstPair;

            foreach (var iElem in _this.Skip(1))
            {
                iPair = oxNext(iElem, iPair.B);
                yield return iPair.A;
            }
        }



    }
}

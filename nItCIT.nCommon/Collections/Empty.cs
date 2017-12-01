using System;
using System.Collections.Generic;

namespace nIt.nCommon
{
    static public class Empty
    {

        static public IStackList<TElement> ReversedList<TElement>()
        {
            return new StackList<TElement>();
        }

        static  public IReadOnlyList<TElement> List<TElement>()
        {
            return new TElement[0];
        } 

        static public IReadOnlyDictionary<TKey, TValue> Dictionary<TKey, TValue>()
        {
            return new Dictionary<TKey, TValue>();
        }

        static public Stack<TElement> Stack<TElement>()
        {
            return new Stack<TElement>();
        }
    }



}

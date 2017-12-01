using System;
using System.Collections.Generic;

namespace nIt.nCommon
{
    static public class Empty
    {

        static public IStackList<TElement> ReversedList<TElement>()
        {
            return new MutableStackList<TElement>();
        }


        static public List<TElement> MutableList<TElement>()
        {
            return new List<TElement>();
        }

        static  public IReadOnlyList<TElement> List<TElement>()
        {
            return new TElement[0];
        } 

        static public IReadOnlyDictionary<TKey, TValue> Dictionary<TKey, TValue>()
        {
            return new Dictionary<TKey, TValue>();
        }

        static public Stack<TElement> MutableStack<TElement>()
        {
            return new Stack<TElement>();
        }
    }



}

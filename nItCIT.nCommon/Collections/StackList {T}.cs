﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{

    public interface IStackList<out T>
    {

        IEnumerable<T> FromBottomToTop();
        IEnumerable<T> FromTopToBottom();
    }


    static public class ext_IStackList
    {
        static public IStackList<T> Append<T>(this IStackList<T> _this, T element)
        {
            return new StackList<T>(_this.FromBottomToTop().Add(element));
        }
    }

    public class StackList<T> : IStackList<T>
    {
        Stack<T> _stack;

        public StackList()
        {
            _stack = new Stack<T>();
        }

        public StackList(IEnumerable<T> other)
        {
            _stack = new Stack<T>(other);
        }


        public IEnumerable<T> FromBottomToTop()
            => _stack.Reverse();



        public IEnumerable<T> FromTopToBottom()
            => _stack;
    }
}

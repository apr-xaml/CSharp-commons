using nIt.nCommon;
using nIt.nCommon.nAsserions;
using nIt.nCommon.nExecutionResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nItCIT.nCommon.ExecutionResult.classes
{
    public class SingleItemResult<TItem> : IFuncResult<TItem, IXor2<NoneElementsResult, MoreThanOneElementsResult<TItem>>>
    {
        readonly TItem _item;
        private NoneElementsResult _noneElementsMatching;
        private MoreThanOneElementsResult<TItem> _moreThanTwoElementsMatching;

        public SingleItemResult(TItem item)
        {
            _item = item;
            this.Kind = Xor2Enum.A;
        }

        public SingleItemResult()
        {

        }


        static public implicit operator SingleItemResult<TItem>(TItem item)
            => new SingleItemResult<TItem>(item);



        static public SingleItemResult<TItem> NoneElementsMatching => new SingleItemResult<TItem>
        {
            _noneElementsMatching = new NoneElementsResult(),
            Kind = Xor2Enum.B
        };


        static public SingleItemResult<TItem> MoreThanTwoElementsMatching(TItem elem1, TItem elem2) => new SingleItemResult<TItem>
        {
            _moreThanTwoElementsMatching = new MoreThanOneElementsResult<TItem>(elem1, elem2),
            Kind = Xor2Enum.B
        };

        public TItem A
        {
            get
            {
                _Assert.IsTrue(this.IsA);
                return _item;
            }
        }


        public IXor2<NoneElementsResult, MoreThanOneElementsResult<TItem>> B
        {
            get
            {
                _Assert.IsTrue(this.IsB);

                if (_noneElementsMatching != null)
                {
                    return new Xor2<NoneElementsResult, MoreThanOneElementsResult<TItem>>(_noneElementsMatching);
                }
                else
                {
                    return new Xor2<NoneElementsResult, MoreThanOneElementsResult<TItem>>(_moreThanTwoElementsMatching);
                }

            }
        }
        public bool IsA => (Kind == Xor2Enum.A);

        public bool IsB => (Kind == Xor2Enum.B);

        public Xor2Enum Kind { get; private set; }

           

        
    }



    public class NoneElementsResult
    {

    }


    public class MoreThanOneElementsResult<TItem>
    {
        public MoreThanOneElementsResult(TItem obj1, TItem obj2)
        {
            Obj1 = obj1;
            Obj2 = obj2;
        }




        public TItem Obj1 { get; }
        public TItem Obj2 { get; }
    }
}

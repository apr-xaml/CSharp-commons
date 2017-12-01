using nIt.nCommon.nExecutionResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public interface IEqualityComparerWithReason<TElement, TNotEqualReason> : IEqualityComparer<TElement>
    {
        EqualityResult<TElement, TNotEqualReason> AreEqual(TElement x, TElement y);
    }


    public class EqualityResult
    {
        private EqualityResult()
        {

        }
        static public OkEqualityResult Ok { get; } = new OkEqualityResult();


        public class OkEqualityResult 
        {
            public OkEqualityResult()
            {
            }
        }
    }



    public class EqualityResult<TElement, TNotEqualReason>
    {

        private EqualityResult()
        {
            AreEqual = true;
            NotEqualReason = Maybe.NoValue;
        }

        public EqualityResult(TNotEqualReason notEqualReason)
        {
            AreEqual = false;
            NotEqualReason = notEqualReason;
        }

        public static implicit operator bool(EqualityResult<TElement, TNotEqualReason> self)
        {
            return self.AreEqual;
        }

        public static implicit operator EqualityResult<TElement, TNotEqualReason>(TNotEqualReason reason)
        {
            return new EqualityResult<TElement, TNotEqualReason>(reason);
        }


        public static implicit operator EqualityResult<TElement, TNotEqualReason>(EqualityResult.OkEqualityResult ok)
        {
            return new EqualityResult<TElement, TNotEqualReason>();
        }

        public bool AreEqual { get; }
        public Maybe<TNotEqualReason> NotEqualReason { get; }
    }
}

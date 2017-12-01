using nIt.nCommon.nExecutionResult;
using nItCIT.nCommon.nNumbers;
using System;

namespace nIt.nCommon.nNumbers
{
    static public class Int32Algebra
    {
        static public IFuncResult<PositiveOrZeroInt32, OverflowException> Add(PositiveOrZeroInt32 x1, PositiveOrZeroInt32 x2)
            => SystemInt32Algebra.Add(x1.Int32Value, x2.Int32Value)
                .Tranform(x => new PositiveOrZeroInt32(x));

        public static NegativeOrZeroInt32 OpositeOf(PositiveOrZeroInt32 x) => new NegativeOrZeroInt32(-x.Int32Value);

        public static PositiveOrZeroInt32 OpositeOf(NegativeOrZeroInt32 x) => new PositiveOrZeroInt32(-x.Int32Value);



        static public IFuncResult<PositiveOrZeroInt32, OverflowException> Substract(PositiveOrZeroInt32 x1, PositiveOrZeroInt32 x2)
        => SystemInt32Algebra.Substract(x1.Int32Value, x2.Int32Value)
                .Tranform(x => new PositiveOrZeroInt32(x));

        public static IFuncResult<NegativeInt32, OverflowException> Substract(NegativeInt32 x1, PositiveOrZeroInt32 x2)
        {
            throw new NotImplementedException();
        }







        #region IZeroInt32

        public static TInt32 Add<TInt32>(TInt32 x1, IZeroInt32 x2) where TInt32 : IAnyInt32
        {
            throw new NotImplementedException();
        }

        public static TInt32 Add<TInt32>(IZeroInt32 x1, TInt32 x2) where TInt32 : IAnyInt32
        {
            throw new NotImplementedException();
        }


        public static TInt32 Substract<TInt32>(TInt32 x1, IZeroInt32 x2) where TInt32 : IAnyInt32
        {
            throw new NotImplementedException();
        }


        public static TInt32 Substract<TInt32>(IZeroInt32 x1, TInt32 x2) where TInt32 : IAnyInt32
        {
            throw new NotImplementedException();
        }

        public static IZeroInt32 Multiply(IZeroInt32 x1, IAnyInt32 x2)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region IAnyInt32

        public static IAnyInt32 Add(IAnyInt32 x1, IAnyInt32 x2)
        {
            throw new NotImplementedException();
        }

        public static IAnyInt32 Substract(IAnyInt32 x1, IAnyInt32 x2)
        {
            throw new NotImplementedException();
        }


        public static IAnyInt32 Multiply(IAnyInt32 x1, IAnyInt32 x2)
        {
            throw new NotImplementedException();
        }

        public static IAnyInt32 Divide(IAnyInt32 x1, INonZeroInt32 x2)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

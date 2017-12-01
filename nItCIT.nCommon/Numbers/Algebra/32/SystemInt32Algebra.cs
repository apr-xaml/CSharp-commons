using nIt.nCommon.nExecutionResult;
using System;

namespace nIt.nCommon.nNumbers
{
    static public class SystemInt32Algebra
    {



        static IFuncResult<int, OverflowException> _Execute(int x, int y, Func<int, int, int> oxOperationFunc)
        {

            try
            {
                var res = checked(oxOperationFunc.Invoke(x, y));
                return new FuncResult<int, OverflowException>(res);

            }
            catch (OverflowException exc)
            {
                return new FuncResult<int, OverflowException>(exc);
            }
        }


        static public IFuncResult<int, OverflowException> Add(int x1, int x2) => _Execute(x1, x2, SystemOperations.Sum);

        static public IFuncResult<int, OverflowException> Substract(int x1, int x2) => _Execute(x1, x2, SystemOperations.Difference);

        static public IFuncResult<int, OverflowException> Multiply(int x1, int x2) => _Execute(x1, x2, SystemOperations.Product);

        static public IFuncResult<int, OverflowException> Divide(int x1, int x2) => _Execute(x1, x2, SystemOperations.Division);
    }





    static public class SystemOperations
    {
        static public int Sum(int x, int y) => (x + y);
        static public int Difference(int x, int y) => (x - y);
        static public int Product(int x, int y) => (x * y);

        static public int Division(int x, int y) => (x / y);
    }

}

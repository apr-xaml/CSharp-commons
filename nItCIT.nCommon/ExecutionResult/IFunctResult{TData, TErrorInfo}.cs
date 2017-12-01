using System;

namespace nIt.nCommon.nExecutionResult
{




    public interface IFuncResult<out TData, out TErrorInfo> :  IXor2<TData, TErrorInfo>
    {
        new TData A { get; }
        new TErrorInfo B { get; }

        new bool IsA { get; }
        new bool IsB { get; }

        new Xor2Enum Kind { get; }
    }



    static public class ext_IFuncResult
    {
        static public IFuncResult<TNewData, TErrorInfo> Tranform<TData, TNewData, TErrorInfo>(this IFuncResult<TData, TErrorInfo> _this, Func<TData, TNewData> oxTransformFunc)
        {


            switch (_this.Kind)
            {
                case Xor2Enum.A:
                    {
                        var newVal = oxTransformFunc(_this.A);
                        return new FuncResult<TNewData, TErrorInfo>(newVal);
                    }
                case Xor2Enum.B:
                    {
                        return new FuncResult<TNewData, TErrorInfo>(_this.B);
                    }
                default:
                    throw NotPreparedForThatCase.CannotHappenException;
            }


        }
    }
}

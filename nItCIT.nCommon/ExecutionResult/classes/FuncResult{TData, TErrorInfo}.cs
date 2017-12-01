namespace nIt.nCommon.nExecutionResult
{
    public class FuncResult<TData, TErrorInfo> : IFuncResult<TData, TErrorInfo>
    {
        Xor2<TData, TErrorInfo> _xor2;

        public FuncResult(TData result)
        {
            _xor2 = new Xor2<TData, TErrorInfo>(result);
        }

        public FuncResult(TErrorInfo errorInfo)
        {
            _xor2 = new Xor2<TData, TErrorInfo>(errorInfo);
        }



        static public implicit operator FuncResult<TData, TErrorInfo>(TData data) => new FuncResult<TData, TErrorInfo>(data);

        static public implicit operator FuncResult<TData, TErrorInfo>(TErrorInfo error) => new FuncResult<TData, TErrorInfo>(error);


        public TData Result => _xor2.A;

        public TData A => _xor2.A;

        public TErrorInfo B => _xor2.B;

        public bool IsA => _xor2.IsA;

        public bool IsB => _xor2.IsB;

        public Xor2Enum Kind => _xor2.Kind;

    }




}

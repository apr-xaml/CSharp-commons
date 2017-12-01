namespace nIt.nCommon.nExecutionResult
{
    public class ActionResult<TErrorInfo> : IActionResult<TErrorInfo>
    {
        Maybe<TErrorInfo> _maybeError;

        public ActionResult(TErrorInfo errorInfo)
        {
            _maybeError = errorInfo;
        }

        public ActionResult()
        {
            _maybeError = Maybe.NoValue;
        }

        static public IActionResult<TErrorInfo> Ok() => new ActionResult<TErrorInfo>();

        static public IActionResult<TErrorInfo> FromError(TErrorInfo errorInfo) => new ActionResult<TErrorInfo>(errorInfo);

        public TErrorInfo Error => Return.OnlyIf(_maybeError.Value, IsB);

        public bool IsOk => !_maybeError.Exists;

        public bool IsA => IsOk;

        public bool IsB => (!IsA);

        public SuccessfulActionResult A => new SuccessfulActionResult();

        public TErrorInfo B => _maybeError.Value;

        public Xor2Enum Kind => (_maybeError.Exists) ? Xor2Enum.B : Xor2Enum.A;
    }
}


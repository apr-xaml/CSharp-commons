namespace nIt.nCommon.nExecutionResult
{

    public class SuccessfulActionResult
    {

    }


    public interface IActionResult<out TErrorInfo> : IXor2<SuccessfulActionResult, TErrorInfo>
    {

    }


}

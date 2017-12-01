using System.Threading.Tasks;
namespace nIt.nCommon
{
    static public class ext_TaskCompletionSource
    {
        public static TaskCompletionSource<object> SetNullResultAndMarkAsCompleted(this TaskCompletionSource<object> _this)
        {
            _this.SetResult(null);
            
            return _this;
        }
    }
}

namespace nIt.nCommon
{
    static public class ext_String
    {
        static public bool IsNullOrWhite(this string _this)
        {
            return string.IsNullOrWhiteSpace(_this);
        }

        static public string Form(this string _this, params object[] args)
        {
            return string.Format(_this, args);
        }
    }
}

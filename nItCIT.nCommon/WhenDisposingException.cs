using System;


namespace nIt.nCommon
{
    public class WhenDisposingException : Exception
    {


        public WhenDisposingException(Exception exc) : base(string.Empty, exc)
        {

        }
    }
}

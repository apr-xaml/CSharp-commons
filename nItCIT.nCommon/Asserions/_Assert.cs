namespace nIt.nCommon.nAsserions
{
    static public class _Assert
    {
        static public void DoesNotExtend<T>(object obj)
        {
            var isOk = !obj.GetType().Extends<T>();
            Throw.IfNot(isOk);
        }

        static public void IsTrue(bool assertion)
        {
            Throw.IfNot(assertion);
        }
    }
}

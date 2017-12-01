namespace nIt.nCommon.FSharp
{
    public struct And<T1, T2>
    {
        object _obj;

        public bool IsT1 => _obj is T1;
        public bool ist2 => _obj is T2;

        public T1 AsT1 => (T1)_obj;
        public T2 AsT2 => (T2)_obj;


        public And(T1 obj1)
        {
            _obj = obj1;
        }

        public And(T2 obj2)
        {
            _obj = obj2;
        }
    }
}





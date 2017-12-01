using System.Collections.Generic;


namespace nIt.nCommon.nIObjectWithId
{
    class ByIdComparer : IEqualityComparer<IObjectWithId>
    {
        private static ByIdComparer _INSTANCE = new ByIdComparer();
        static public ByIdComparer Instance { get { return _INSTANCE; } }

        private ByIdComparer()
        {

        }

        public bool Equals(IObjectWithId x, IObjectWithId y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(IObjectWithId obj)
        {
            return obj.Id;
        }
    }
}

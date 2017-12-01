using System.Collections.Generic;


namespace nIt.nCommon
{
    internal class EntityContentComparer<TEntity> : IEqualityComparer<TEntity>
    {
        private static EntityContentComparer<TEntity> _INSTANCE = new EntityContentComparer<TEntity>();
        private EntityContentComparer()
        {

        }

        static public EntityContentComparer<TEntity> Instance { get { return _INSTANCE; } }

        public bool Equals(TEntity x, TEntity y)
        {
            //if (x == null && y == null)
            //    return true;

            //if (x == null || y == null)
            //{
            //    return false;
            //}
            
            return EntityContentHelper.AreEqual(x, y);
        }

        public int GetHashCode(TEntity obj)
        {
            return EntityContentHelper.GetContentHashCode(obj);
        }
    }
}

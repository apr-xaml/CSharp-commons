using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace nIt.nCommon
{
    static public class EntityContentHelper
    {
        static public void CopyContent<TSource, TDest>(TSource source, TDest dest, params Expression<Func<object>>[] exceptFor)
            where TDest : TSource
        {

            if (object.ReferenceEquals(source, dest))
            {
                return;
            }

            var sourceProps = Introspector.GetAllPublicImplicitInstanceProps<TSource>();
            //var destProps = accessType == null ?
            //    Introspector.GetAllPubliInstanceProps<TDest>()
            //    : Introspector.GetAllPubliInstanceProps(accessType);

            var destProps = Introspector.GetAllPublicImplicitInstanceProps<TDest>();

            var exceptForNames = exceptFor.Select(x => FullNameOf.Property(x));

            var propsToCopy = sourceProps.Where(x => !exceptForNames.Contains(x.Name));

            foreach (var iProp in propsToCopy)
            {
                var sourceVal = iProp.GetValue(source);

                var destProp = destProps.Single(x => x.Name == iProp.Name);

                destProp.SetValue(dest, sourceVal);
            }

        }


        static public bool AreEqual<TEntity>(TEntity obj1, TEntity obj2, params Expression<Func<object>>[] exceptFor)
        {
            var allProps = Introspector.GetAllPublicImplicitInstanceProps<TEntity>();

            var exceptForNames = exceptFor.Select(x => FullNameOf.Property(x));

            var propsToExamine = allProps.Where(x => !exceptForNames.Contains(x.Name));

            return propsToExamine
                .All(x => object.Equals(x.GetValue(obj1), x.GetValue(obj2)));
        }

        static public int GetContentHashCode<TEntity>(TEntity obj, params Expression<Func<object>>[] exceptFor)
        {
            return 0;
        }


        public static void CopyContent<TSource>(TSource source, OxUpdateProperty oxUpdateProperty, params Expression<Func<object>>[] exceptFor)
        {
            var sourceProps = Introspector.GetAllPublicImplicitInstanceProps<TSource>();

            var exceptForNames = exceptFor.Select(x => FullNameOf.Property(x));

            var propsToCopy = sourceProps.Where(x => !exceptForNames.Contains(x.Name));

            foreach (var iProp in propsToCopy)
            {
                var sourceVal = iProp.GetValue(source);

                oxUpdateProperty.Invoke(iProp.Name, sourceVal);
            }
        }




        static public IEqualityComparer<TEntity> Comparer<TEntity>() { return EntityContentComparer<TEntity>.Instance; }
    }


}

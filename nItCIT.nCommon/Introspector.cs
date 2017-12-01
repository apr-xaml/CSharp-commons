using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace nIt.nCommon
{
    //[System.Diagnostics.DebuggerStepThrough]
    static public class Introspector
    {

        public static PropertyInfo GetPublicImplicitInstancePropByShortName(string shortName, Type owner)
        {
            return GetAllPublicImplicitInstanceProps(owner)
                    .Where(x => x.Name == shortName)
                    .Single();
        }

        public static PropertyInfo[] GetAllPublicImplicitInstanceProps<TItem>()
        {
            return GetAllPublicImplicitInstanceProps(typeof(TItem));
        }

        public static PropertyInfo[] GetAllPublicImplicitInstanceProps(Type type)
        {
            var props = type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public);

            return props;
        }




        public static IEnumerable<PropertyInfoWithPrefix> GetAllPublicImplicitInstancePropsRecursive<TOwner, TTypeToExpand>(TOwner owner)
            where TOwner : class
            where TTypeToExpand : class
        {

            foreach (var item in _GetAllPublicImplicitInstancePropsRecursive<TOwner, TTypeToExpand>(owner, Maybe.NoValue))
            {
                yield return item;
            }
        }



        static IEnumerable<PropertyInfoWithPrefix> _GetAllPublicImplicitInstancePropsRecursive<TOwner, TTypeToExpand>(object owner, Maybe<IPropertyDescriptionChain<TOwner>> chain)
            where TOwner : class
            where TTypeToExpand : class
        {
            var directProps = Introspector.GetAllPublicImplicitInstanceProps(owner.GetType());

            var nodesToExpand = directProps
                .Where(x => x.PropertyType.Extends<TTypeToExpand>())
                .ToList();

            foreach (var iDirect in directProps)
            {

                var newChain = (chain.Exists) ?
                        (chain.Value.Add(new PropertyDescription(chain.Value.Nodes.Last().ValueType, typeof(TTypeToExpand), iDirect.Name)))
                      :
                        (new PropertyDescriptionChain<TOwner, TTypeToExpand>(new PropertyDescription<TOwner, TTypeToExpand>(propName: iDirect.Name), Empty.List<IPropertyDescription>()))
                        ;

                if (!iDirect.PropertyType.Extends<TTypeToExpand>())
                {
                    yield return new PropertyInfoWithPrefix(newChain, iDirect, owner);
                }
                else
                {
                    foreach (var item in _GetAllPublicImplicitInstancePropsRecursive<TOwner, TTypeToExpand>(iDirect, new Maybe<IPropertyDescriptionChain<TOwner>>(newChain)))
                    {
                        yield return item;
                    }
                }

            }


        }

        public class PropertyInfoWithPrefix
        {
            public PropertyInfoWithPrefix(IPropertyDescriptionChain path, PropertyInfo propertyDescription, object owner)
            {
                Path = path;
                Info = propertyDescription;
                Owner = owner;
            }

            public IPropertyDescriptionChain Path { get; }
            public PropertyInfo Info { get; }
            public object Owner { get; }
        }
    }
}

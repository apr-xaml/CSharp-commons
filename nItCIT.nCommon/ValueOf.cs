using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace nIt.nCommon
{
    static public class ValueOf
    {

        static public IReadOnlyList<TEnum> AllEnums<TEnum>()
            where TEnum : struct
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
        }


        static public TValue Property<TOwner, TValue>(IPropertyDescription<TOwner, TValue> propertyDescription, TOwner owner)
            where TOwner : class
            => (TValue)ValueOf.PropertyByInterface(propertyDescription.ShortName, owner, propertyDescription.AccessingType);




        static public TValue Property<TOwner, TValue>(IXor2<IPropertyDescription<TOwner, TValue>, IPropertyDescriptionChain<TOwner, TValue>> propertyDescription, TOwner owner)
            where TOwner : class
        {
            if (propertyDescription.IsA)
            {

                return Property(propertyDescription.A, owner);
            }
            else
            {
                return (TValue)_ValueOf_PropertyByDescriptionPathRec(propertyDescription.B.Nodes, owner);
            }
        }

        static public T Property<T>(string propName, object obj)
        {
            var splitted = propName.Split('.');

            return (T)_ValueOf_PropertyByNamePathRec(splitted, obj);
        }


        static public TResult Property<TResult>(Expression<Func<TResult>> exProperty)
        {
            return (TResult)exProperty.Compile().Invoke();
        }


        static public TResult Property<TOwner, TResult>(Expression<Func<TOwner, TResult>> exProperty, TOwner owner)
        {
            return (TResult)exProperty.Compile().Invoke(owner);
        }


        public static object Property(string propName, object owner, BindingFlags extraBindingFlags = BindingFlags.Default)
        {
            var prop = owner
                .GetType()
                .GetProperty(propName, BindingFlags.Public | BindingFlags.Instance | extraBindingFlags);

            return prop.GetValue(owner);
        }

        public static object PropertyByInterface<TAccessingType>(string propName, TAccessingType owner)
        {
            var prop = typeof(TAccessingType).GetProperty(propName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

            if (prop == null)
            {
                var message = string.Format("Cannot locate property={0} on type={1}", prop, typeof(TAccessingType).Name);
                throw new MemberAccessException(message);
            }

            return prop.GetValue(owner);
        }


        public static object PropertyByInterface(string propName, object owner, Type ownerAccessType)
        {
            var prop = ownerAccessType.GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);

            if (prop == null)
            {
                throw new MemberAccessException();
            }

            return prop.GetValue(owner);
        }

        private static object _ValueOf_SimpleAccessPropertyByName(string propName, object obj)
        {
            var prop = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
            var val = prop.GetValue(obj);
            return val;
        }

        private static object _ValueOf_PropertyByNamePathRec(IEnumerable<string> propNames, object obj)
        {

            if (propNames.Count() == 1)
            {
                return _ValueOf_SimpleAccessPropertyByName(propNames.Single(), obj);
            }
            else
            {

                var nextObj = _ValueOf_SimpleAccessPropertyByName(propNames.First(), obj);
                return _ValueOf_PropertyByNamePathRec(propNames.Skip(1), nextObj);
            }
        }

        private static object _ValueOf_PropertyByDescriptionPathRec(IEnumerable<IPropertyDescription> properties, object owner)
        {
            if (properties.Any())
            {
                return owner;
            }
            else
            {
                var property = properties.First();
                var value = ValueOf.PropertyByInterface(property.ShortName, owner, property.AccessingType);
                return _ValueOf_PropertyByDescriptionPathRec(properties.Skip(1), value);
            }

        }

    }
}

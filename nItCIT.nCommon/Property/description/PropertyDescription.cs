using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public class PropertyDescription : IPropertyDescription
    {


        public string ShortName { get; }
        public Type AccessingType { get; }
        public Type ValueType { get; }

        public PropertyDescription(Type ownerType, Type valueType, string shortName)
        {
            ShortName = shortName;
            AccessingType = ownerType;
            this.ValueType = valueType;
        }





        string IPropertyOrChainDescription.PathName => ShortName;

        string IPropertyDescription.ShortName => ShortName;

        Type IPropertyOrChainDescription.AccessingType => AccessingType;

        Type IPropertyOrChainDescription.ValueType => ValueType;

        IReadOnlyList<IPropertyDescription> IPropertyOrChainDescription.Nodes => Singleton.List(this);



        public static IXor2<IPropertyDescription<TAccessingType, TValue>, IPropertyDescriptionChain<TAccessingType, TValue>, IPropertyOrChainDescription> FromExpression<TAccessingType, TValue>(Expression<Func<TAccessingType, TValue>> exProperty)
          where TAccessingType : class
        {
            var xor = _DescriptionFromExpression<TAccessingType, TValue>(SplitMemberPath.ToMemberExpressions(exProperty));
            return new Xor2<IPropertyDescription<TAccessingType, TValue>, IPropertyDescriptionChain<TAccessingType, TValue>, IPropertyOrChainDescription>(xor);
        }






        private static IXor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription> _DescriptionFromExpression<TOwner>(IReadOnlyList<MemberExpression> expressions)
            where TOwner : class
        {

            var first = new PropertyDescription<TOwner>(expressions.First().Type, expressions.First().Member.Name);

            var rest = expressions.Skip(1).ToList();

            var linkedDescriptions = _LinkDescriptionsRec(first, rest).ToList();

            if (!linkedDescriptions.Any())
            {
                return new Xor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription>(first);
            }
            else
            {
                return new Xor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription>(new PropertyDescriptionChain<TOwner>(first, linkedDescriptions));
            }
        }


        private static IXor2<IPropertyDescription<TOwner, TValue>, IPropertyDescriptionChain<TOwner, TValue>, IPropertyOrChainDescription> _DescriptionFromExpression<TOwner, TValue>(IReadOnlyList<MemberExpression> expressions)
            where TOwner : class
        {

            var rest = expressions.Skip(1).ToList();

            if (!rest.Any())
            {
                var single = new PropertyDescription<TOwner, TValue>(expressions.First().Member.Name);
                return new Xor2<IPropertyDescription<TOwner, TValue>, IPropertyDescriptionChain<TOwner, TValue>, IPropertyOrChainDescription>(single);
            }

            var firstExpression = expressions.First();
            var first = new PropertyDescription<TOwner>(firstExpression.Type, firstExpression.Member.Name);

            var linkedDescriptions = _LinkDescriptionsRec(first, rest).ToList();

            var chain = new PropertyDescriptionChain<TOwner, TValue>(first, linkedDescriptions);
            return new Xor2<IPropertyDescription<TOwner, TValue>, IPropertyDescriptionChain<TOwner, TValue>, IPropertyOrChainDescription>(chain);
        }

        private static IEnumerable<IPropertyDescription> _LinkDescriptionsRec(IPropertyDescription previous, IEnumerable<MemberExpression> rest)
        {
            if (!rest.Any())
            {
                yield break;
            }

            var expr = rest.First();
            var firstFromRest = new PropertyDescription(previous.ValueType, expr.Type, expr.Member.Name);
            yield return firstFromRest;

            foreach (var iNode in _LinkDescriptionsRec(firstFromRest, rest.Skip(1)))
            {
                yield return iNode;
            }
        }



        public static IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> FromPath(IReadOnlyList<string> path, Type accessingType, Type valueType)
        {
            var firstPropName = path.First();
            
            var rest = path.Skip(1);

            if (!rest.Any())
            {
                var firstPropDesc = new PropertyDescription(accessingType, valueType, firstPropName);
                return new Xor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription>(firstPropDesc);
            }
            else
            {
                var firstPropDesc = new PropertyDescription(accessingType, TypeOf.Property(firstPropName, accessingType), firstPropName);
                var firstFromRest = rest.First();
                var restOfNodes = rest.SelectWithHistory
                    (
                        oxStart:
                            xStr => new PropertyDescription(firstPropDesc.ValueType, TypeOf.Property(firstFromRest, firstPropDesc.ValueType), firstFromRest),
                        oxOnLast:
                            (xStr, xPrevNode) => new PropertyDescription(xPrevNode.ValueType, valueType, xStr),
                        oxNext:
                            (xStr, xPrevNode) => new PropertyDescription(xPrevNode.ValueType, TypeOf.Property(xStr, xPrevNode.ValueType), xStr)

                    )
                    .ToList();

                var chain = new PropertyDescriptionChain(firstPropDesc, restOfNodes);

                return new Xor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription>(chain);
            }
        }
    }
}

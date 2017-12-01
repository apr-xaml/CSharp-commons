using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    static public class ext_IXorWithCommonDescription
    {
        static public IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> Add(this IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> _this, IPropertyDescription other)
        {
            return _ExtendXor(_this, new[] { other });
        }


        static public IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> Add(this IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> _this, IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> other)
        {
            return _ExtendXor(_this, other.Common.Nodes);
        }



        static public IXor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription> Add<TOwner>(this IXor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription> _this, IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> other)
            where TOwner :class
        {
            return _ExtendXor(_this, other.Common.Nodes);
        }

        private static IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> _ExtendXor(IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> _this, IReadOnlyList<IPropertyDescription> otherNodes)
        {
            if (_this.IsA)
            {
                var singleProp = _this.A;
                var chain = new PropertyDescriptionChain(singleProp, otherNodes);

                return new Xor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription>(chain);
            }
            else
            {
                var chain = _this.B;
                var others = chain.Nodes.Skip(1).Concat(otherNodes).ToList();
                var chainExpanded = new PropertyDescriptionChain(chain.FirstNode, others);

                return new Xor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription>(chainExpanded);
            }
        }


        private static IXor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription> _ExtendXor<TOwner>(IXor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription> _this, IReadOnlyList<IPropertyDescription> otherNodes)
            where TOwner: class
        {
            if (_this.IsA)
            {
                var singleProp = _this.A;
                var chain = new PropertyDescriptionChain<TOwner>(singleProp, otherNodes);

                return new Xor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription>(chain);
            }
            else
            {
                var chain = _this.B;
                var others = chain.Nodes.Skip(1).Concat(otherNodes).ToList();
                var chainExpanded = new PropertyDescriptionChain<TOwner>(chain.FirstNode, others);

                return new Xor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription>(chainExpanded);
            }
        }

        static public IXor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription> Add<TOwner, TIntermediateValue>(this IXor2<IPropertyDescription<TOwner, TIntermediateValue>, IPropertyDescriptionChain<TOwner, TIntermediateValue>, IPropertyOrChainDescription> _this, IXor2<IPropertyDescription<TIntermediateValue>, IPropertyDescriptionChain<TIntermediateValue>, IPropertyOrChainDescription> other)
           where TOwner : class
           where TIntermediateValue : class
        {

            if (_this.IsA)
            {
                var singleProp = _this.A;
                var chain = new PropertyDescriptionChain<TOwner>(singleProp, other.Common.Nodes);

                return new Xor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription>(chain);
            }
            else
            {
                var chain = _this.B;
                var others = chain.Nodes.Skip(1).Concat(other.Common.Nodes).ToList();
                var chainExpanded = new PropertyDescriptionChain<TOwner>(chain.FirstNode, others);

                return new Xor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription>(chainExpanded);
            }
        }



        static public IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> Add<TOwner, TIntermediateValue, TFinalValue>(this IXor2<IPropertyDescription<TOwner, TIntermediateValue>, IPropertyDescriptionChain<TOwner, TIntermediateValue>, IPropertyOrChainDescription> _this, IXor2<IPropertyDescription<TIntermediateValue, TFinalValue>, IPropertyDescriptionChain<TIntermediateValue, TFinalValue>, IPropertyOrChainDescription> other)
             where TOwner : class
             where TIntermediateValue : class
        {

            if (_this.IsA)
            {
                var singleProp = _this.A;
                var chain = new PropertyDescriptionChain<TOwner, TFinalValue>(singleProp, other.Common.Nodes);

                return new Xor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription>(chain);
            }
            else
            {
                var chain = _this.B;
                var others = chain.Nodes.Skip(1).Concat(other.Common.Nodes).ToList();
                var chainExpanded = new PropertyDescriptionChain(chain.FirstNode, others);

                return new Xor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription>(chainExpanded);
            }
        }




    }




}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{

    public class PropertyDescriptionChain<TOwner> : IPropertyDescriptionChain<TOwner>
        where TOwner : class
    {
        public PropertyDescriptionChain(IPropertyDescription<TOwner> firstNode, IReadOnlyList<IPropertyDescription> otherNodes)
        {
            this.FirstNode = firstNode;
            this.Nodes = ListFrom.Elements(firstNode).Concat(otherNodes).ToList();
        }

        public IPropertyDescription<TOwner> FirstNode { get; }

        public IReadOnlyList<IPropertyDescription> Nodes { get; }

        public Type AccessingType => typeof(TOwner);

        public string PathName => FullNameOf.From(Nodes.Select(x => x).ToList());

        public Type ValueType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IPropertyDescription IPropertyDescriptionChain.FirstNode => FirstNode;
    }


    public class PropertyDescriptionChain<TOwner, TValue> : PropertyDescriptionChain<TOwner>, IPropertyDescriptionChain<TOwner, TValue>
        where TOwner : class
    {

        public PropertyDescriptionChain(IPropertyDescription<TOwner> firstNode, IReadOnlyList<IPropertyDescription> otherNodes):
            base(firstNode, otherNodes)
        {
            
            
        }



    }




}

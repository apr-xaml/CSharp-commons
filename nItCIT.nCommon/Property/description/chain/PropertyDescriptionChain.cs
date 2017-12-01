using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{

    public class PropertyDescriptionChain : IPropertyDescriptionChain
    {
        public PropertyDescriptionChain(IPropertyDescription firstNode, IReadOnlyList<IPropertyDescription> otherNodes)
        {
            this.FirstNode = firstNode;
            this.Nodes = ListFrom.Elements(firstNode).Concat(otherNodes).ToList();
        }

        public IPropertyDescription FirstNode { get; }

        public IReadOnlyList<IPropertyDescription> Nodes { get; }

        public string PathName => FullNameOf.From(Nodes.Select(x => x).ToList());

        IPropertyDescription IPropertyDescriptionChain.FirstNode => FirstNode;



        Type IPropertyOrChainDescription.AccessingType => FirstNode.AccessingType;

        string IPropertyOrChainDescription.PathName => PathName;

        Type IPropertyOrChainDescription.ValueType => Nodes.Last().ValueType;
    }


}

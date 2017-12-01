using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public interface IPropertyDescriptionChain : IPropertyOrChainDescription
    {

        IPropertyDescription FirstNode { get; }
        IReadOnlyList<IPropertyDescription> Nodes { get; }
    }


    public interface IPropertyDescriptionChain<in TOwner> : IPropertyDescriptionChain
        where TOwner : class
    {

        new IPropertyDescription<TOwner> FirstNode { get; }
    }


    public interface IPropertyDescriptionChain<in TOwner, out TValue> : IPropertyDescriptionChain<TOwner>
        where TOwner: class

    {

    }

}

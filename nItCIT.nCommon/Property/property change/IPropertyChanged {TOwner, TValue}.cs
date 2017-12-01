using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{


    public interface IPropertyChanged<TOwner> : IPropertyChanged
       where TOwner : class
    {

        new IXor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription> PropertyDescription { get; }
    }



    public interface IPropertyChanged<TOwner, out TValue> : IValueChanged<TValue>, IPropertyChanged<TOwner>
        where TOwner : class
    {
        new TValue NewValue { get; }
        new TValue OldValue { get; }

        new IXor2<IPropertyDescription<TOwner, TValue>, IPropertyDescriptionChain<TOwner, TValue>, IPropertyOrChainDescription> PropertyDescription { get; }
    }



   
}

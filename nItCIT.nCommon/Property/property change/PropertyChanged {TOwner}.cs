using nIt.nCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{



    public class PropertyChanged<TOwner> : IPropertyChanged<TOwner>
        where TOwner : class
    {
        public PropertyChanged(IXor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription> propertyDescription, object oldValue, object newValue)
        {
            this.PropertyDescription = propertyDescription;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public object NewValue { get; }
        public object OldValue { get; }

        public IXor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription> PropertyDescription { get; }

        object IValueChanged.NewValue => NewValue;

        object IValueChanged.OldValue => OldValue;

        IXor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription> IPropertyChanged<TOwner>.PropertyDescription
            => PropertyDescription;

        IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> IPropertyChanged.PropertyDescription 
            => PropertyDescription;

       
    }
}

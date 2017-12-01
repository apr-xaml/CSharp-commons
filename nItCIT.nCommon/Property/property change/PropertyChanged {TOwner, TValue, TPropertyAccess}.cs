using nIt.nCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{



    public class PropertyChanged<TOwner, TValue, TPropertyAccess> : IPropertyChanged<TOwner, TValue>
        where TOwner : class, TPropertyAccess
        where TPropertyAccess: class
    {
        public PropertyChanged(Xor2<IPropertyDescription<TPropertyAccess, TValue>, IPropertyDescriptionChain<TPropertyAccess, TValue>, IPropertyOrChainDescription> propertyDescription, TValue oldValue, TValue newValue)
        {
            this.PropertyDescription = propertyDescription;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public TValue NewValue { get; }
        public TValue OldValue { get; }

        public IXor2<IPropertyDescription<TOwner, TValue>, IPropertyDescriptionChain<TOwner, TValue>, IPropertyOrChainDescription> PropertyDescription { get; }

        object IValueChanged.NewValue => NewValue;

        object IValueChanged.OldValue => OldValue;

        IXor2<IPropertyDescription<TOwner>, IPropertyDescriptionChain<TOwner>, IPropertyOrChainDescription> IPropertyChanged<TOwner>.PropertyDescription
            => PropertyDescription;

        IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> IPropertyChanged.PropertyDescription 
            => PropertyDescription;

       
    }
}

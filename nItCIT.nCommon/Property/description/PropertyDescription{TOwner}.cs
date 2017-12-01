using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public class PropertyDescription<TOwner> : IPropertyDescription<TOwner>
       where TOwner : class
    {
        private readonly string _shortName;
        private readonly Type _valueType;

        public PropertyDescription(Type valueType, string shortName)
        {
            _shortName = shortName;
            _valueType = valueType;
        }



        Type IPropertyOrChainDescription.AccessingType => typeof(TOwner);

        IReadOnlyList<IPropertyDescription> IPropertyOrChainDescription.Nodes => Singleton.List(this);

        string IPropertyOrChainDescription.PathName => _shortName;

        string IPropertyDescription.ShortName => _shortName;

        Type IPropertyOrChainDescription.ValueType => _valueType;
    }
}

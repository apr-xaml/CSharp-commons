using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public class PropertyDescription<TOwner, TPropertyValue> : IPropertyDescription<TOwner, TPropertyValue>
     where TOwner : class
    {
        private readonly string _shortName;

        public PropertyDescription(string propName)
        {
            _shortName = propName;
        }



        string IPropertyDescription.ShortName => _shortName;

        string IPropertyOrChainDescription.PathName => _shortName;

        Type IPropertyOrChainDescription.AccessingType => typeof(TOwner);

        Type IPropertyOrChainDescription.ValueType => typeof(TPropertyValue);

        IReadOnlyList<IPropertyDescription> IPropertyOrChainDescription.Nodes => Singleton.List(this);
    }

}

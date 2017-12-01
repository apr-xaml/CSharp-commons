using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{

    static public class ext_IPropertyDescriptionChain
    {
        static public IPropertyDescriptionChain<TOwner, TNewValue> Add<TOwner, TValue, TNewValue>(this IPropertyDescriptionChain<TOwner, TValue> _this, IPropertyDescription<TValue, TNewValue> propertyDescription)
            where TOwner : class
            where TValue : class
        {
            return new PropertyDescriptionChain<TOwner, TNewValue>(_this.FirstNode, _this.Nodes.Skip(1).Add(propertyDescription).ToList());
        }


        static public IPropertyDescriptionChain<TOwner> Add<TOwner>(this IPropertyDescriptionChain<TOwner> _this, IPropertyDescription propertyDescription)
            where TOwner : class
        {
            return new PropertyDescriptionChain<TOwner>(_this.FirstNode, _this.Nodes.Skip(1).Add(propertyDescription).ToList());
        }
    }
}

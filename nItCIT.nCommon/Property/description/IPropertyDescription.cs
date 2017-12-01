using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public interface IPropertyDescription : IPropertyOrChainDescription
    {
        string ShortName { get; }
    }





    public interface IPropertyDescription<in TOwner> : IPropertyDescription
        where TOwner : class
    {
    }

 

    public interface IPropertyDescription<in TOwner, out TPropertyValue> : IPropertyDescription<TOwner>
        where TOwner : class
    {

    }


    static public class ext_IPropertyDescription
    {
        static public IPropertyDescription<TOwner> DeclareOwner<TOwner>(this IPropertyDescription _this)
            where TOwner : class
        {
            if(_this is IPropertyDescription<TOwner>)
            {
                return (IPropertyDescription<TOwner>)_this;
            }
            else
            {
                Throw.IfNot(_this.AccessingType.Extends<TOwner>());
                return new PropertyDescription<TOwner>(_this.ValueType, _this.ShortName);
            }
        }
    }



}

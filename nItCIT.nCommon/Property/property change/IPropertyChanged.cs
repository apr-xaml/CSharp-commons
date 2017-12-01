using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public interface IPropertyChanged : IValueChanged
    {
        IXor2<IPropertyDescription, IPropertyDescriptionChain, IPropertyOrChainDescription> PropertyDescription { get; }
    }
}

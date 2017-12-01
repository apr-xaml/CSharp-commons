using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public interface IPropertyOrChainDescription
    {
        string PathName { get; }
        Type AccessingType { get; }
        Type ValueType { get; }

        IReadOnlyList<IPropertyDescription> Nodes { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    static public class JoinMemberPath
    {
        static public string Of(IReadOnlyList<string> path)
        {
            return string.Join(FullNameOf.DotSymbol, path);
        }
    }
}

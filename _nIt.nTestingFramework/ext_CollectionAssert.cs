using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _nIt.nTestingFramework
{
    static public class ext_CollectionAssert
    {
        static public void IsEmpty<T>(this CollectionAssert _this, IEnumerable<T> enumerable, string msg = null)
        {
            var msgFinalTemplate = msg ?? "Enumerable was expected to empty but it contained {0} elements";
            var count = enumerable.Count();
            Assert.IsTrue(count == 0, string.Format(msgFinalTemplate, count));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace _nIt.nTestingFramework
{
    static public class ext_Assert
    {

        static public void IsOfType<TExpectedType>(this Assert _this, object obj, string msg = null)
        {
            var msgFinal = msg ?? $"Expected type was {typeof(TExpectedType).Name}. Actual type is {obj.GetType().Name}";
            Assert.IsInstanceOfType(obj, typeof(TExpectedType), msgFinal);
        }

        
    }
}

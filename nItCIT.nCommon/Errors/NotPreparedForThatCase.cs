using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    static public class NotPreparedForThatCase
    {
        public static Exception CannotHappenException = new InvalidOperationException();

        static public InvalidOperationException UnexpectedEnumException<TValue>(TValue enumCase, string msg = null)
            where TValue : struct
        {
            return new InvalidOperationException(MessageForEnum(enumCase));
        }


        static public InvalidOperationException UnexpectedTypeException(Type unexpectedType, string msg = null)
        {
            return new InvalidOperationException(MessageForType(unexpectedType));
        }

        static public string MessageForEnum<TEnumValue>(TEnumValue value, string msg = null)
            where TEnumValue : struct
        {
            return $"Not prepared for enum = {value}. Detailed message is = ({msg ?? "None"})";
        }

        static public string MessageForType(Type unexpectedType, string msg = null)
        {
            return $"Not prepared for type = {unexpectedType.Name}. Detailed message is = ({msg ?? "None"})";
        }
    }
}

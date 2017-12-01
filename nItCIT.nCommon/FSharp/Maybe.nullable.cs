using nIt.nCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static nItCIT.nCommon.nFSharp.MaybeNullable;

namespace nItCIT.nCommon.nFSharp
{
    public struct MaybeNullable<T>
    {
        private readonly object _value;

        public bool Exists { get; }

        

        private MaybeNullable(object value, bool valueExists)
        {
            this._value = value;
            this.Exists = valueExists;
            
        }
        static public MaybeNullable<T> WithValue(T value) => new MaybeNullable<T>(value: value, valueExists: true);

        static public MaybeNullable<T> NoValue => new MaybeNullable<T>(value: null, valueExists: false);

        public object Value
        {
            get
            {
                Throw.IfNot(Exists);

                return _value;
            }
        }



        static public implicit operator MaybeNullable<T>(T value) => MaybeNullable<T>.WithValue(value);

        static public implicit operator MaybeNullable<T>(MybeNullableNoValue noValue) => MaybeNullable<T>.NoValue;

       

      


    }


    public struct MaybeNullable
    {

        static public readonly MybeNullableNoValue NoValue = new MybeNullableNoValue();

        public struct MybeNullableNoValue
        {

        }
    }
}

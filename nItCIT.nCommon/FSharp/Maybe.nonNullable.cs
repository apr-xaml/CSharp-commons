using System;

namespace nIt.nCommon
{

    public struct Maybe
    {
        static public MaybeWithNoValue NoValue { get; } = new MaybeWithNoValue();

        public static bool Exists<T>(Maybe<T> maybe)
        {
            return maybe.Exists;
        }

        public static T MustExistValue<T>(Maybe<T> maybe)
        {
            return maybe.Value;
        }

        public static Maybe<T> FromReference<T>(T value) where T : class
        {
            if (value == null)
            {
                return NoValue;
            }
            else
            {
                return value;
            }
        }


        public static Maybe<T> FromStruct<T>(T value) where T : struct => new Maybe<T>(value);

        public static Maybe<T> FromNullableStruct<T>(T? value) where T : struct
        {
            if (value == null)
            {
                return Maybe.NoValue;
            }
            else
            {
                return value.Value;
            }
        }


        public static Maybe<T> FromNullableReference<T>(T value) where T : class
        {
            if (value == null)
            {
                return Maybe.NoValue;
            }
            else
            {
                return value;
            }
        }

    }


    public struct MaybeWithNoValue
    {

    }



    public struct Maybe<T>
    {
        private readonly T _value;

        public Maybe(T value)
        {
            Throw.IfNot(value != null);
            _value = value;

            Exists = true;
        }

        public T Value
        {
            get
            {
                Throw.IfNot(Exists);
                return _value;
            }
        }


        public Maybe<TOther> Convert<TOther>(Func<T, TOther> oxConvertFunc)
        {
            if (!Exists)
            {
                return Maybe.NoValue;
            }
            else
            {
                var converted = oxConvertFunc(this._value);
                return converted;
            }

        }

        public bool Exists { get; }
        public static Maybe<T> NoValue => Maybe.NoValue;


        public override string ToString()
        {
            if (!Exists)
            {
                return "None";
            }
            else
            {
                return $"Maybe with {this._value}";
            }
        }

        #region operators
        static public implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }




        static public implicit operator Maybe<T>(MaybeWithNoValue value)
        {
            return new Maybe<T>();
        }
        #endregion
    }
}

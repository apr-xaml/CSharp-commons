using System;

namespace nIt.nCommon
{
    static public class Function
    {
        static public Func<T> CreatingObject<T>()
          where T : new()
        {
            return () => new T();
        }


        public static Func<TObject> ReturningObject<TObject>(TObject obj)
        {
            return () => obj;
        }


    }


    static public class ActionWithWeakendInput<TBaseInput>
    {
        public static Action<TBaseInput> From<TInputExtended>(Action<TInputExtended> oxAction)
            where TInputExtended : TBaseInput
        {



            void oxWithWeakendInputAction(TBaseInput x)
            {
                TInputExtended input = (TInputExtended)x;
                oxAction(input);
            };


            return oxWithWeakendInputAction;
        }
    }
}

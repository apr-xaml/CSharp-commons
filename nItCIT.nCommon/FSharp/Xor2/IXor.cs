using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{






    static public class UpCastXor
    {
        static public UpCastXorCont<TBaseAType, TBaseBType> To<TBaseAType, TBaseBType>()
        {
            return new UpCastXorCont<TBaseAType, TBaseBType>();
        }



        public class UpCastXorCont<TBaseAType, TBaseBType>
        {
            internal UpCastXorCont()
            {

            }

            public Xor2<TBaseAType, TBaseBType> From<TTypeA, TTypeB>(IXor2<TTypeA, TTypeB> xor)
                where TTypeA : TBaseAType
                where TTypeB : TBaseBType
            {
                if (xor.IsA)
                {
                    return (Xor2<TBaseAType, TBaseBType>)xor.A;
                }
                else
                {
                    return (Xor2<TBaseAType, TBaseBType>)xor.B;
                }
            }


        }
    }


    #region Unpack
    static public class UnpackXor
    {
        static public UnpackXorCont<TCommon> ToCommonValue<TCommon>()

        {
            return new UnpackXorCont<TCommon>();
        }



        public class UnpackXorCont<TCommonValue>
        {
            internal UnpackXorCont()
            {

            }

            public TCommonValue From<TAType, TBType>(IXor2<TAType, TBType> xor2)
                where TAType : TCommonValue
                where TBType : TCommonValue
            {
                if (xor2.IsA)
                {
                    return xor2.A;
                }
                else
                {
                    return xor2.B;

                }
            }

            public TCommonValue From<TA, TB, TC>(IXor3<TA, TB, TC> xor3)
                where TA : TCommonValue
                where TB : TCommonValue
                where TC : TCommonValue
            {
                if (xor3.IsA)
                {
                    return xor3.A;
                }
                else if(xor3. IsB)
                {
                    return xor3.B;

                }
                else
                {
                    return xor3.C;
                }
            }

        }
    }
    #endregion
}

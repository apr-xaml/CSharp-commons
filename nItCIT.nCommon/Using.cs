using System;

namespace nIt.nCommon
{
    static public class Using
    {
        static public Invoker<TResource> Resource<TResource>(Func<TResource> oxResource)
            where TResource : IDisposable
        {
            return new Invoker<TResource>(oxResource);
        }


    }

    public class Invoker<TResource>
        where TResource : IDisposable
    {
        private Func<TResource> _oxResource;
        public Invoker(Func<TResource> oxResource)
        {
            this._oxResource = oxResource;
        }


        public TResult Get<TResult>(Func<TResource, TResult> oxGetResult)
        {
            using (var res = _oxResource())
            {
                return oxGetResult(res);
            }
        }


    }
}

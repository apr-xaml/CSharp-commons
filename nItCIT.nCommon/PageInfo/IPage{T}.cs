using System;
using System.Collections.Generic;

namespace nIt.nCommon.nPage
{
    public interface IPage<out T> : IPageInfo
    {
        int CountAll { get; }
        IReadOnlyCollection<T> Items { get; }

        IPage<TNewResult> Transform<TNewResult>(Func<T, TNewResult> oxTransform);
    }
}

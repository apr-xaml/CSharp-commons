using System;
using System.Collections.Generic;
using System.Linq;

namespace nIt.nCommon.nPage
{
    public class PageDto<T> : PageInfoDto, IPage<T>
    {
        public int CountAll { get; set; }
        public IReadOnlyCollection<T> Items { get; set; }

        public static IPage<TResultItem> FromPageInfo<TResultItem>(IPageInfo pageInfo, IReadOnlyCollection<TResultItem> items, int countAll)
        {
            return new PageDto<TResultItem>
            {
                Items = items,
                PageNumber = pageInfo.PageNumber,
                PageSize = pageInfo.PageSize,
                CountAll = countAll
            };
        }

        public IPage<TNewResult> Transform<TNewResult>(Func<T, TNewResult> oxTransform)
        {
            return new PageDto<TNewResult>
            {
                Items = Items.Select(oxTransform).ToArray(),
                PageNumber = PageNumber,
                PageSize = PageSize,
                CountAll = CountAll
            };
        }
    }
}

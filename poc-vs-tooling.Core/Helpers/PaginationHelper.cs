using System;
using System.Collections.Generic;
using System.Text;

namespace poc_vs_tooling.Core.Helpers
{
    public static class PaginationHelper
    {
        public static int GetPages(int pageSize, int totalResults)
            => (totalResults % pageSize) == 0
            ? totalResults / pageSize
            : totalResults / pageSize + 1;
    }
}

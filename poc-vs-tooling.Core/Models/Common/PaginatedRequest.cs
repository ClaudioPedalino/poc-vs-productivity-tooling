using System;
using System.Collections.Generic;
using System.Text;

namespace poc_vs_tooling.Core.Models.Common
{
    public abstract class GetWithPagination
    {
        public GetWithPagination()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public virtual int PageNumber { get; set; }
        public virtual int PageSize { get; set; }
    }
}

using System.Collections.Generic;

namespace poc_vs_tooling.Core.Models.Common
{
    public class PaginatedResult<T> : Result
    {
        public PaginatedResult(List<T> data, int totalCount, int pageSize, int totalPages)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            TotalPages = totalPages;
            Data = data;
        }

        public PaginatedResult(List<T> data)
        {
            TotalCount = 0;
            PageSize = 0;
            TotalPages = 0;
            Data = data;
        }


        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<T> Data { get; set; }


        public PaginatedResult<T> Success(int totalCount, int pageSize, int totalPages, List<T> data = default)
           => new PaginatedResult<T>(data, totalCount, pageSize, totalPages) { HasErrors = false, Data = data };

        public PaginatedResult<T> Error(string message, List<T> data = default)
            => new PaginatedResult<T>(data) { HasErrors = true, Message = message };

        public PaginatedResult<T> NotFound(List<T> data = default)
            => new PaginatedResult<T>(data) { HasErrors = true, Message = "No se encontró un registro con la información enviada" };
    }
}

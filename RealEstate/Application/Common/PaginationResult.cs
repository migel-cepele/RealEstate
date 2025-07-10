namespace RealEstate.API.Application.Common
{
    public class PaginationResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public long LastId { get; set; }
        public int TotalPages { get; set; }
        public List<T>? Results { get; set; }
    }
}

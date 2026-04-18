namespace MiniProject.DTOs
{
    public class PaginationDto
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public List<GetProductDto> Data { get; set; }
    }
}

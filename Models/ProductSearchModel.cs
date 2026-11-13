namespace Day3_sv.Models
{
    public class ProductSearchModel
    {
        public string Keyword { get; set; } = string.Empty;

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 5;
    }
}
namespace Api.Core.Features.Products.Queries.Response
{
    public class GetProductByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public List<string> Photos { get; set; } = new List<string>();

        public string Description { get; set; } = String.Empty;
        public string CategoryName { get; set; }
    }
}

namespace Api.Core.Features.Orders.Queries.Responses
{
    public class GetSingleOrderResponse
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        public string Size { get; set; } // Assuming sizes are stored as a comma-separated string

        public string Phone { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public string Notes { get; set; }

        public List<string> PicsCustom { get; set; } = new List<string>();
    }
}

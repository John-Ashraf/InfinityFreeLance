using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data.Entities.Tables
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        public string Size { get; set; } // Assuming sizes are stored as a comma-separated string

        public string Phone { get; set; }

        public string Address { get; set; }

        public string? Notes { get; set; }

        // List of custom photos as byte arrays
        public List<string> PicsCustom { get; set; } = new List<string>();
    }
}

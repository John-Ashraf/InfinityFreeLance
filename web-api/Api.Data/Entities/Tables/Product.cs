using System.ComponentModel.DataAnnotations;

namespace Api.Data.Entities.Tables
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public List<string> Photos { get; set; } = new List<string>();

        public string Description { get; set; } = String.Empty;

        public Category ProductCategory { get; set; }
    }
}

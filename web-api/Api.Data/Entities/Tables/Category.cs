namespace Api.Data.Entities.Tables
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Photo { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

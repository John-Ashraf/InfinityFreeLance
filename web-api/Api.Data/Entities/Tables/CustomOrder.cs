namespace Api.Data.Entities.Tables;
public class CustomOrder
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Size { get; set; }
    public string Notes { get; set; }
    public string Address { get; set; }
    public double TotalPrice { get; set; }
    public string Phone { get; set; }
    public DateTime Date { get; set; }

    public List<string> Photos { get; set; } = new List<string>();
}

namespace Api.Data.Entities.Tables;
public class CustomOrder
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Size { get; set; }
    public string Notes { get; set; }
    public string Address { get; set; }
    public List<string> Photos { get; set; }
}

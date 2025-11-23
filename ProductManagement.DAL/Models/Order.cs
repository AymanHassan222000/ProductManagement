namespace ProductManagement.DAL.Models;

public class Order
{
    public int OrderId { get; set; }
    public int CustmerId { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }

    public ICollection<Product> Products { get; set; }
}

namespace ProductManagement.BLL.DTOs.OrderDTOs;

public abstract class OrderBaseDto
{
    public int CustmerId { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }

}

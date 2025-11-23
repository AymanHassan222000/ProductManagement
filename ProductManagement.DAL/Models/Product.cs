using System.ComponentModel.DataAnnotations;

namespace ProductManagement.DAL.Models;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public double Price { get; set; }
    public int Stock { get; set; }

    public int? OrderId { get; set; }
    public Order Order { get; set; }
}

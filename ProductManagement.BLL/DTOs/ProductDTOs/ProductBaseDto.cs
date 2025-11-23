using System.ComponentModel.DataAnnotations;

namespace ProductManagement.BLL.DTOs.ProductDTOs;

public abstract class ProductBaseDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Range(0, double.MaxValue)]
    public double Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    public int? OrderId { get; set; }

}

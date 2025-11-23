using System.ComponentModel.DataAnnotations;

namespace ProductManagement.BLL.DTOs.ProductDTOs;

public class ProductReadDto : ProductBaseDto
{
    public int ProductId { get; set; }

}

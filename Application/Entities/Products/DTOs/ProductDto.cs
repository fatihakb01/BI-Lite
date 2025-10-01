namespace Application.Entities.Products.DTOs;

public class ProductDto : BaseProductDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
}

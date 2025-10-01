namespace Application.Entities.Products.DTOs;

public class BaseProductDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? SKU { get; set; }
    public decimal Price { get; set; }
    public Guid CompanyId { get; set; }
}

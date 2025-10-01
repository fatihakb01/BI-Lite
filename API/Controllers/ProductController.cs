using Application.Entities.Products.DTOs;
using Application.Entities.Products.Features.Commands;
using Application.Entities.Products.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductController(IMediator mediator) : BaseApiController(mediator)
{
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetProduct.Query { Id = id }));
    }

    [HttpGet("company/{companyId}")]
    public async Task<ActionResult<ProductDto>> GetProductsByCompanyId(Guid companyId)
    {
        return HandleResult(await Mediator.Send(new GetProductsByCompanyId.Query { CompanyId = companyId }));
    }    

    [HttpGet]
    public async Task<ActionResult<ProductDto>> GetProducts()
    {
        return HandleResult(await Mediator.Send(new GetProducts.Query()));
    }
    
    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(
        [FromBody] CreateProductDto productDto)
    {
        return HandleResult(await Mediator.Send(new CreateProduct.Command { ProductDto = productDto }));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDto>> EditProduct(Guid id,
        [FromBody] EditProductDto productDto)
    {
        return HandleResult(await Mediator.Send(new EditProduct.Command
        {
            Id = id,
            ProductDto = productDto
        }));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> DeleteProduct(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteProduct.Command { Id = id }));
    }
}

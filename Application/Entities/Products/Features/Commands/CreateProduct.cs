using Application.Core;
using Application.Entities.Products.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Products.Features.Commands;

public class CreateProduct
{
    public class Command : IRequest<Result<ProductDto>>
    {
        public required CreateProductDto ProductDto { get; set; }
    }

    public class Handler(IRepository<Product> repository, IMapper mapper)
        : IRequestHandler<Command, Result<ProductDto>>
    {
        public async Task<Result<ProductDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request.ProductDto);

            await repository.AddAsync(product, cancellationToken);

            var result = await repository.SaveChangesAsync(cancellationToken);

            if (!result)
                return Result<ProductDto>.Failure("Failed to create product", 400);

            var createdProductDto = mapper.Map<ProductDto>(product);

            return Result<ProductDto>.Success(createdProductDto);
        }
    }
}

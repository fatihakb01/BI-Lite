using Application.Core;
using Application.Entities.Products.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Products.Features.Commands;

public class EditProduct
{
    public class Command : IRequest<Result<EditProductDto>>
    {
        public Guid Id { get; set; }
        public required EditProductDto ProductDto { get; set; }
    }

    public class Handler(IRepository<Product> repository, IMapper mapper)
        : IRequestHandler<Command, Result<EditProductDto>>
    {
        public async Task<Result<EditProductDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (product == null)
                return Result<EditProductDto>.Failure("Product not found", 404);

            mapper.Map(request.ProductDto, product);

            var result = await repository.SaveChangesAsync(cancellationToken);

            if (!result)
                return Result<EditProductDto>.Failure("Failed to update product", 400);

            var updatedProductDto = mapper.Map<EditProductDto>(product);

            return Result<EditProductDto>.Success(updatedProductDto);
        }
    }
}

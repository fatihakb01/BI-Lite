using Application.Core;
using Application.Entities.Products.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Products.Features.Queries;

public class GetProduct
{
    public class Query : IRequest<Result<ProductDto>>
    {
        public required Guid Id { get; set; }
    }

    public class Handler(IRepository<Product> repository, IMapper mapper)
        : IRequestHandler<Query, Result<ProductDto>>
    {
        public async Task<Result<ProductDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (product == null)
                return Result<ProductDto>.Failure("Product not found", 404);

            var productDto = mapper.Map<ProductDto>(product);

            return Result<ProductDto>.Success(productDto);
        }
    }
}

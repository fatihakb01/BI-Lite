using Application.Core;
using Application.Entities.TransactionLineItems.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.TransactionLineItems.Features.Queries;

public class GetTransactionLineItem
{
    public class Query : IRequest<Result<TransactionLineItemDto>>
    {
        public required Guid Id { get; set; }
    }

    public class Handler(IRepository<TransactionLineItem> repository, IMapper mapper)
        : IRequestHandler<Query, Result<TransactionLineItemDto>>
    {
        public async Task<Result<TransactionLineItemDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var transactionLineItem = await repository
                .GetByIdAsync(request.Id, cancellationToken);

            if (transactionLineItem == null)
                return Result<TransactionLineItemDto>.Failure("Transaction line item not found", 404);

            var transactionLineItemDto = mapper.Map<TransactionLineItemDto>(transactionLineItem);

            return Result<TransactionLineItemDto>.Success(transactionLineItemDto);
        }
    }
}

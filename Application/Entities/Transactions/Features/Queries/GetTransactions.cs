using Application.Core;
using Application.Entities.Transactions.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Transactions.Features.Queries;

public class GetTransactions
{
    public class Query : IRequest<Result<List<TransactionDto>>> { }

    public class Handler(IRepository<Transaction> repository, IMapper mapper)
        : IRequestHandler<Query, Result<List<TransactionDto>>>
    {
        public async Task<Result<List<TransactionDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var transactions = await repository.GetAllAsync(cancellationToken);

            if (transactions == null)
                return Result<List<TransactionDto>>.Failure("Transactions not found", 404);

            var transactionDtos = mapper.Map<List<TransactionDto>>(transactions);

            return Result<List<TransactionDto>>.Success(transactionDtos);
        }
    }
}

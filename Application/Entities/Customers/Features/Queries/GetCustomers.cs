using System;
using Application.Core;
using Application.Entities.Companies.DTOs;
using Application.Entities.Customers.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Entities.Customers.Features.Queries;

public class GetCustomers
{
    public class Query : IRequest<Result<List<CustomerDto>>> { }

    public class Handler(IRepository<Customer> repository, IMapper mapper)
        : IRequestHandler<Query, Result<List<CustomerDto>>>
    {
        public async Task<Result<List<CustomerDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var customers = await repository.GetAllAsync(cancellationToken);

            if (customers == null)
                return Result<List<CustomerDto>>.Failure("Customers not found", 404);

            var customerDtos = mapper.Map<List<CustomerDto>>(customers);

            return Result<List<CustomerDto>>.Success(customerDtos);
        }
    }
}

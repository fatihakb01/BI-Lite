using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Companies.Queries.GetBusiness;

public class GetCompany
{
    public class Query : IRequest<Result<CompanyDto>>
    {
        public required Guid Id { get; set; }
    }

    public class Handler(IRepository<Company> repository, IMapper mapper)
        : IRequestHandler<Query, Result<CompanyDto>>
    {
        public async Task<Result<CompanyDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var company = await repository
                .GetByIdAsync(request.Id, cancellationToken);

            if (company == null)
                return Result<CompanyDto>.Failure("Company not found", 404);

            var companyDto = mapper.Map<CompanyDto>(company);

            return Result<CompanyDto>.Success(companyDto);
        }
    }
}

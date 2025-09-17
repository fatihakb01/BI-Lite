using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Companies.Queries.GetBusiness;

public class GetCompanies
{
    public class Query : IRequest<Result<List<CompanyDto>>> { }

    public class Handler(IRepository<Company> repository, IMapper mapper)
        : IRequestHandler<Query, Result<List<CompanyDto>>>
    {
        public async Task<Result<List<CompanyDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var companies = await repository.GetAllAsync(cancellationToken);

            if (companies == null)
                return Result<List<CompanyDto>>.Failure("Companies not found", 404);

            var companyDtos = mapper.Map<List<CompanyDto>>(companies);

            return Result<List<CompanyDto>>.Success(companyDtos);
        }
    }
}

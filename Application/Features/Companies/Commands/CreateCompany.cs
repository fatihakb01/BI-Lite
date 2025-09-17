using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Companies.Commands;

public class CreateCompany
{
    public class Command : IRequest<Result<CompanyDto>>
    {
        public required CreateCompanyDto CompanyDto { get; set; }
    }

    public class Handler(IRepository<Company> repository, IMapper mapper)
        : IRequestHandler<Command, Result<CompanyDto>>
    {
        public async Task<Result<CompanyDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var company = mapper.Map<Company>(request.CompanyDto);

            await repository.AddAsync(company, cancellationToken);

            var result = await repository.SaveChangesAsync(cancellationToken);

            if (!result)
                return Result<CompanyDto>.Failure("Failed to create business", 400);

            var createdCompanyDto = mapper.Map<CompanyDto>(company);

            return Result<CompanyDto>.Success(createdCompanyDto);
        }
    }
}

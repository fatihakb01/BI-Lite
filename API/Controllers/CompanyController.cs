using Application.DTOs;
using Application.Features.Companies.Commands;
using Application.Features.Companies.Queries.GetBusiness;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CompanyController(IMediator mediator) : BaseApiController(mediator)
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyDto>> GetCompany(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetCompany.Query { Id = id }));
    }

    [HttpGet]
    public async Task<ActionResult<List<CompanyDto>>> GetCompanies()
    {
        return HandleResult(await Mediator.Send(new GetCompanies.Query()));
    }

    [HttpPost]
    public async Task<ActionResult<CompanyDto>> CreateCompany([FromBody] CreateCompanyDto companyDto)
    {
        return HandleResult(await Mediator.Send(new CreateCompany.Command { CompanyDto = companyDto }));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CompanyDto>> EditCompany(Guid id, [FromBody] EditCompanyDto companyDto)
    {
        return HandleResult(await Mediator.Send(new EditCompany.Command { Id = id, CompanyDto = companyDto }));
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> DeleteCompany(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteCompany.Command { Id = id }));
    }
}
